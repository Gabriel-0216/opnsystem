using Application.Commands.Respostas;
using MediatR;

namespace Application.Commands.Requisicao;

public class CriarSugestaoRequisicao : IRequest<CriarSugestaoResposta>
{
    public string NomeColaborador { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Justificativa { get; set; } = string.Empty;
    public int DepartamentoId { get; set; }
}