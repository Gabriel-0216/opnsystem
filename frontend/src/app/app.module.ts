import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DepartamentosListaComponent } from './departamentos-lista/departamentos-lista.component';
import { SugestoesComponent } from './sugestoes/sugestoes.component';
import { DepartamentosCadastroComponent } from './departamentos-cadastro/departamentos-cadastro.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SugestaoCadastroComponent } from './sugestao-cadastro/sugestao-cadastro.component';
import { NgxSpinnerModule } from 'ngx-spinner';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DepartamentosListaComponent,
    SugestoesComponent,
    DepartamentosCadastroComponent,
      SugestaoCadastroComponent
   ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    ModalModule.forRoot(),
    NgxSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
