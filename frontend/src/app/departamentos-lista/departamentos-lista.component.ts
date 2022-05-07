import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Departamento } from '../_models/Departamento';
import { DepartamentosService } from '../_services/Departamentos.service';

@Component({
  selector: 'app-departamentos-lista',
  templateUrl: './departamentos-lista.component.html',
  styleUrls: ['./departamentos-lista.component.scss']
})
export class DepartamentosListaComponent implements OnInit {

  public departamentos: Departamento[] = [];
  public departamentosFiltrado: Departamento[] = [];

  constructor(private departamentoService: DepartamentosService,
     private toastr: ToastrService,
     private spinner: NgxSpinnerService,
     private modalService: BsModalService,
     private fb: FormBuilder) { }


     modalRef?: BsModalRef;
     form: FormGroup = new FormGroup({});
     departamentoId : number = 0;
     departamento = {} as Departamento;
     private _filtrarNomeDepartamento: string = '';

     public get filtrarNomeDepartamento() : string{
       return this._filtrarNomeDepartamento;
     }
     public set filtrarNomeDepartamento(value: string){
      this._filtrarNomeDepartamento = value;
      this.departamentosFiltrado = this.filtrarNomeDepartamento ? this.filtrarDepartamentos(this.filtrarNomeDepartamento) : this.departamentos;
     }


  ngOnInit(): void {
    this.spinner.show();
    this.getDepartamentos()
    this.spinner.hide();
    this.validation();
  }

  get f() : any {
    return this.form.controls;
  }


  public validation() : void{
    this.form = this.fb.group({
      nome : ['', Validators.required]})
  }
  public getDepartamentos() : void {
    this.departamentoService.getDepartamentos().subscribe({
      next: (departs : Departamento[]) => {
        this.departamentos = departs;
        this.departamentosFiltrado = departs;
        this.toastr.success('Carregado com sucesso.');
      },
      error: (error: any) =>{
        console.log(error)
        this.toastr.error('Erro ao carregar departamentos.');
      },
    })
  }

  filtrarDepartamentos(filtrarNomeDepartamento: string) : Departamento[]{
    filtrarNomeDepartamento = filtrarNomeDepartamento.toLocaleLowerCase();
    return this.departamentos.filter(
      (departamento : any) => departamento.nome.toLocaleLowerCase().indexOf(filtrarNomeDepartamento) !== -1)
  }

  public removerRegistro(departamentoId : number) : void{
    this.spinner.show();
    this.departamentoService.deleteDepartamento(departamentoId)
    .subscribe(
      (result: any ) => {
        this.getDepartamentos();
        this.toastr.success('Deletado com sucesso.');

      },
      (error : any) => {
        console.log(error);
        this.toastr.error('Ocorreu um erro ao tentar deletar, verifique se esse departamento já possuí sugestões cadastradas.');

      }
    )
    this.spinner.hide();
  }

  openModal(event: any, template: TemplateRef<any>, departamentoId: number) {
    event.stopPropagation();
    this.departamentoId = departamentoId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirmarUpdate(): void {
    this.modalRef?.hide()
    if(this.form.valid){
      this.departamento = this.form.value;
      this.departamento.id = this.departamentoId;
      this.departamentoService.put(this.departamento).subscribe(
        (departRetorno : Departamento) => {
          this.toastr.success('Editado com sucesso.');
          setTimeout(() => {
            this.getDepartamentos();
          }, 1000);
        },
        (error : any) =>{
          console.log(error);
          this.toastr.error('Ocorreu um erro ao tentar atualizar o registro.');
        }
      )
    }

  }

  cancelarUpdate(): void {
    this.modalRef?.hide();
    this.toastr.error('Operação cancelada.');
  }

}
