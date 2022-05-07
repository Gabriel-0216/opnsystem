import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sugestao } from '../_models/Sugestao';
import { take, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SugestoesService {
  baseURL = 'https://localhost:7080/api/Sugestoes'

constructor(private http: HttpClient) { }

getSugestoes() : Observable<Sugestao[]>{
  return this.http.get<Sugestao[]>(this.baseURL);
}

getSugestaoById(id: number) : Observable<Sugestao>{
  return this.http.get<Sugestao>(`${this.baseURL}/id/${id}`);
}

post(sugestao : Sugestao) : Observable<Sugestao>{
  return this.http.post<Sugestao>(this.baseURL, sugestao)
  .pipe(take(1));
}

getSugestoesPorDepartamentoId(departamentoId: number) : Observable<Sugestao[]>{
  return this.http.get<Sugestao[]>(`${this.baseURL}/filtrar-por-departamento/id/${departamentoId}`);
}


}
