using Application.Commands.Respostas;
using MediatR;

namespace Application.Commands.Requisicao;

public class CriarDepartamentoRequisicao : IRequest<CriarDepartamentoResposta>
{
    public string Nome { get; set; } = string.Empty;
}