using Application.Queries.Consulta;
using Application.Queries.Resposta;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using MediatR;

namespace Application.Queries.Handlers;

public class ListarDepartamentosHandler : IRequestHandler<ListarDepartamentosConsulta, IEnumerable<ListarDepartamentosResposta>>
{
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public ListarDepartamentosHandler(IDepartamentoRepositorio departamentoRepositorio)
    {
        _departamentoRepositorio = departamentoRepositorio;
    }

    public async Task<IEnumerable<ListarDepartamentosResposta>> Handle(ListarDepartamentosConsulta request, CancellationToken cancellationToken)
    {
        var listaDepartamentos = await _departamentoRepositorio.GetAll(request.ListarSugestoes);

        var listaQueSeraRetornada =
            listaDepartamentos
                .Select(p =>
                    new ListarDepartamentosResposta(p.Id, p.Data_Criacao, p.Data_Atualizacao,
                        p.NomeDepartamento.Descricao,
                        p.Sugestoes.Select(k => new ListarDepartamentosResposta.Sugestao(k.Id, k.Data_Criacao,
                            k.Data_Atualizacao, k.Departamento.Id, k.NomeColaborador.Descricao, k.Justificativa,
                            k.Descricao)).ToList()));
        
        return listaQueSeraRetornada;

    }
}