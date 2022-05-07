import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Departamento } from '../_models/Departamento';
import { DepartamentosService } from '../_services/Departamentos.service';

@Component({
  selector: 'app-departamentos-cadastro',
  templateUrl: './departamentos-cadastro.component.html',
  styleUrls: ['./departamentos-cadastro.component.scss']
})
export class DepartamentosCadastroComponent implements OnInit {
form: FormGroup = new FormGroup({});
departamento = {} as Departamento;
departamentoRetorno = {} as Departamento;

get f() : any {
  return this.form.controls;
}

  constructor(private departamentoService: DepartamentosService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation() : void{
    this.form = this.fb.group({
      nome : ['', Validators.required]
    })
  }

  public salvarDepartamento() : void {
    this.spinner.show();
    if(this.form.valid){
      this.departamento = this.form.value;

      this.departamentoService.post(this.departamento).subscribe(
        (departRetorno : Departamento) => {
          this.router.navigate([`departamentos`]);
        },
        (error : any) => {
          console.log(error);
          this.toastr.error('Ocorreu um erro ao tentar salvar o registro.');
        }
      )
    }
    this.spinner.hide();
  }

  public resetForm() : void{
    this.form.reset();
    this.toastr.success('Operação cancelada.');
  }
}
