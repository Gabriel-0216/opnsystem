using Application.Commands.Respostas;
using MediatR;

namespace Application.Commands.Requisicao;

public class DeletarDepartamentoRequisicao : IRequest<DeletarDepartamentoResposta>
{
    public DeletarDepartamentoRequisicao(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}