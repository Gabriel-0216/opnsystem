using Application.Queries.Consulta;
using Application.Queries.Resposta;
using Dominio.DAL.Repositorios.SugestoesRepositorio;
using MediatR;

namespace Application.Queries.Handlers;

public class ListarSugestoesHandler : IRequestHandler<ListarSugestoesConsulta, IEnumerable<ListarSugestoesResposta>>
{
    private readonly ISugestaoRepositorio _sugestaoRepositorio;

    public ListarSugestoesHandler(ISugestaoRepositorio sugestaoRepositorio)
    {
        _sugestaoRepositorio = sugestaoRepositorio;
    }

    public async Task<IEnumerable<ListarSugestoesResposta>> Handle(ListarSugestoesConsulta request, CancellationToken cancellationToken)
    {
        var listaRetornada = await _sugestaoRepositorio
            .GetAll(true);
        var listaParaRetorno =
            listaRetornada.Select(p => new ListarSugestoesResposta(p.Id, p.Data_Criacao, p.Data_Atualizacao,
                p.Departamento.Id,
                new ListarSugestoesResposta.DepartamentoDto(p.Departamento.Id, p.Departamento.Data_Criacao,
                    p.Departamento.Data_Atualizacao, p.Departamento.NomeDepartamento.Descricao),
                p.NomeColaborador.Descricao, p.Justificativa, p.Descricao));

        return listaParaRetorno;
    }
}