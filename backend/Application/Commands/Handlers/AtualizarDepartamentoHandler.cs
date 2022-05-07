using Application.Commands.Requisicao;
using Application.Commands.Respostas;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using MediatR;

namespace Application.Commands.Handlers;

public class AtualizarDepartamentoHandler : IRequestHandler<AtualizarDepartamentoRequisicao, AtualizarDepartamentoResposta>
{
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public AtualizarDepartamentoHandler(IDepartamentoRepositorio departamentoRepositorio)
    {
        _departamentoRepositorio = departamentoRepositorio;
    }

    public async Task<AtualizarDepartamentoResposta> Handle(AtualizarDepartamentoRequisicao request, CancellationToken cancellationToken)
    {
        var resposta = new AtualizarDepartamentoResposta();
        var departamento = await _departamentoRepositorio.GetById(request.Id, asNoTracking: false);
        if (departamento is null)
        {
            resposta.AdicionarErro("Departamento não existe.");
            return resposta;
        }
        departamento.EditarNome(request.Nome);
        if (await _departamentoRepositorio.Update(departamento)) return resposta;
        
        resposta.AdicionarErro("Erro interno do servidor.");
        return resposta;

    }
}