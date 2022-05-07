import { Sugestao } from "./Sugestao";

export interface Departamento{

  id: number;
  nome: string;
  sugestoes: Sugestao[];
}
