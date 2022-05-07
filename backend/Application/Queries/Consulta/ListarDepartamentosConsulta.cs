using Application.Queries.Resposta;
using MediatR;

namespace Application.Queries.Consulta;

public class ListarDepartamentosConsulta : IRequest<IEnumerable<ListarDepartamentosResposta>>
{
    public ListarDepartamentosConsulta(bool incluirSugestoes)
    {
        ListarSugestoes = incluirSugestoes;
    }
    public bool ListarSugestoes { get; set; }
    
}