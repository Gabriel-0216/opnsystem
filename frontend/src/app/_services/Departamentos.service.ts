import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Departamento } from '../_models/Departamento';
import { take, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DepartamentosService {
  baseURL = 'https://localhost:7080/api/Departamentos'


constructor(private http: HttpClient) { }


getDepartamentos() : Observable<Departamento[]>{
  return this.http.get<Departamento[]>(this.baseURL);
}

getDepartamentoById(id: number) : Observable<Departamento>{
  return this.http.get<Departamento>(`${this.baseURL}/id/${id}`);
}

post(departamento : Departamento) : Observable<Departamento>{
  return this.http.post<Departamento>(this.baseURL, departamento)
  .pipe(take(1));
}

public deleteDepartamento(id: number) : Observable<any>{
  return this.http.delete(`${this.baseURL}/id/${id}`)
  .pipe(take(1));
}

put(departamento : Departamento) : Observable<any>{
  return this.http.put(`${this.baseURL}/id/${departamento.id}`, departamento);
}
}
