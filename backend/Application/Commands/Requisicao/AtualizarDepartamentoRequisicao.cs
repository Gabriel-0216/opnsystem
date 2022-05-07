using Application.Commands.Respostas;
using MediatR;

namespace Application.Commands.Requisicao;

public class AtualizarDepartamentoRequisicao : IRequest<AtualizarDepartamentoResposta>
{
    public string Nome { get; set; } = string.Empty;
    public int Id { get;  private set; }

    public void SetId(int id) => Id = id;
}