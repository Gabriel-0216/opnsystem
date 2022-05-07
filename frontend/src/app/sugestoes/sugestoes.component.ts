import { Component, OnInit } from '@angular/core';
import { Sugestao } from '../_models/Sugestao';
import { SugestoesService } from '../_services/Sugestoes.service';
import { Departamento } from '../_models/Departamento';
import { DepartamentosService } from '../_services/Departamentos.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-sugestoes',
  templateUrl: './sugestoes.component.html',
  styleUrls: ['./sugestoes.component.scss']
})
export class SugestoesComponent implements OnInit {
  public sugestoes: Sugestao[] = [];
  public departamentos: Departamento[] = [];
  public sugestoesFiltrado : Sugestao[] = [];
  public departamentoId : any;
  private _departamentoId : any;

  constructor(private sugestaoService: SugestoesService,
    private departamentoService: DepartamentosService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }


    public get departamentoFiltro() : number {
      return this._departamentoId;
    }

    public set departamentoFiltro(value : number){
      this._departamentoId = value;
      this.sugestoesFiltrado = this.filtrarSugestoes(this.departamentoFiltro);
    }


  ngOnInit(): void {
    this.spinner.show();
    this.getSugestoes();
    this.getDepartamentos();
    this.spinner.hide();
  }

  filtrarSugestoes(departamentoId : number) : Sugestao[]{
    if(departamentoId <= 0) return this.sugestoes;
    return this.sugestoes.filter(x => x.departamentoId == departamentoId);

  }

 public getSugestoes() : void {
   this.sugestaoService.getSugestoes().subscribe({
     next: (sugests : Sugestao[]) => {
       this.sugestoes = sugests;
       this.sugestoesFiltrado = sugests;
       this.toastr.success('Carregado com sucesso.');

     },
     error: (error : any) =>{
       console.log(error);
       this.toastr.error('Erro ao carregar sugestões.');
     },
   })
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


}
