import { Departamento } from "./Departamento";

export interface Sugestao{
  id: number;
  nomeColaborador: string;
  departamentoId : number;
  departamento: Departamento;
  descricao: string;
  justificativa: string;
}
