import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartamentosCadastroComponent } from './departamentos-cadastro/departamentos-cadastro.component';
import { DepartamentosListaComponent } from './departamentos-lista/departamentos-lista.component';
import { SugestaoCadastroComponent } from './sugestao-cadastro/sugestao-cadastro.component';
import { SugestoesComponent } from './sugestoes/sugestoes.component';

const routes: Routes = [
  {path: 'departamentos', component: DepartamentosListaComponent},
  {path: 'cadastrar-departamento', component: DepartamentosCadastroComponent},
  {path: 'sugestoes', component: SugestoesComponent},
  {path: 'cadastrar-sugestao', component: SugestaoCadastroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
