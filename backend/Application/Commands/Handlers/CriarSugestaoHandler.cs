using Application.Commands.Requisicao;
using Application.Commands.Respostas;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using Dominio.DAL.Repositorios.SugestoesRepositorio;
using Dominio.Entidades;
using MediatR;

namespace Application.Commands.Handlers;

public class CriarSugestaoHandler : IRequestHandler<CriarSugestaoRequisicao, CriarSugestaoResposta>
{
    private readonly ISugestaoRepositorio _sugestaoRepositorio;
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public CriarSugestaoHandler(ISugestaoRepositorio sugestaoRepositorio, IDepartamentoRepositorio departamentoRepositorio)
    {
        _sugestaoRepositorio = sugestaoRepositorio;
        _departamentoRepositorio = departamentoRepositorio;
    }

    public async Task<CriarSugestaoResposta> Handle(CriarSugestaoRequisicao request, CancellationToken cancellationToken)
    {
        var resposta = new CriarSugestaoResposta();
        var departamento =
            await _departamentoRepositorio.GetById(request.DepartamentoId, asNoTracking: false,
                incluirSugestoes: false);
        if (departamento is null)
        {
            resposta.AdicionarErro("Departamento não existe.");
            return resposta;
        }

        var sugestao = new Sugestao(request.NomeColaborador, departamento, request.Justificativa, request.Descricao);
        if (!sugestao.IsValid)
        {
            resposta.AdicionarErros(sugestao.RetornarNotificacoesString());
            return resposta;
        }

        if (await _sugestaoRepositorio.Add(sugestao)) return resposta;
        
        resposta.AdicionarErro("Erro interno do servidor.");
        return resposta;
    }
}