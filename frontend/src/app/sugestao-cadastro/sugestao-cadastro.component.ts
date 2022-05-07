import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Departamento } from '../_models/Departamento';
import { Sugestao } from '../_models/Sugestao';
import { DepartamentosService } from '../_services/Departamentos.service';
import { SugestoesService } from '../_services/Sugestoes.service';

@Component({
  selector: 'app-sugestao-cadastro',
  templateUrl: './sugestao-cadastro.component.html',
  styleUrls: ['./sugestao-cadastro.component.scss']
})
export class SugestaoCadastroComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  sugestao = {} as Sugestao;
  public departamentos: Departamento[] = [];

  get f() : any{
    return this.form.controls;
  }

  constructor(private departamentoService: DepartamentosService,
    private sugestaoService: SugestoesService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.getDepartamentos()
    this.validation();
    this.spinner.hide();
  }

  public validation() : void{
    this.form = this.fb.group({
      nomeColaborador : ['', Validators.required],
      descricao : ['', Validators.required],
      justificativa : ['', Validators.required],
      departamentoId : ['', Validators.required],
    })
  }

  public salvarSugestao() : void{
    this.spinner.show();
    if(this.form.valid){
      this.sugestao = this.form.value;

      this.sugestaoService.post(this.sugestao).subscribe(
        (sugestRetorno : Sugestao) =>{
          this.toastr.success('Cadastrado', 'Sucesso')
          this.router.navigate([`sugestoes`]);
        },
        (error : any ) => {
          console.log(error);
          this.toastr.error('Ocorreu um erro ao salvar o registro');
        }
      )
    }
    this.spinner.hide();
  }

  public getDepartamentos() : void {
    this.departamentoService.getDepartamentos().subscribe({
      next: (departs : Departamento[]) => {
        this.departamentos = departs
      },
      error: (error: any) =>{
        console.log(error)
      },
    })
  }

  public resetForm() : void{
    this.form.reset();
    this.toastr.error('Operação cancelada.');
  }
}
