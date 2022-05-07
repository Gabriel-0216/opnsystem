using Application.Commands.Requisicao;
using Application.Commands.Respostas;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Commands.Handlers;

public class DeletarDepartamentoHandler : IRequestHandler<DeletarDepartamentoRequisicao, DeletarDepartamentoResposta>
{
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public DeletarDepartamentoHandler(IDepartamentoRepositorio departamentoRepositorio)
    {
        _departamentoRepositorio = departamentoRepositorio;
    }

    public async Task<DeletarDepartamentoResposta> Handle(DeletarDepartamentoRequisicao request, CancellationToken cancellationToken)
    {
        var resposta = new DeletarDepartamentoResposta();
        var departamento = await _departamentoRepositorio.GetById(request.Id, incluirSugestoes: true);
        if (departamento is null)
        {
            resposta.AdicionarErro("Departamento não existe");
            return resposta;
        }

        if (departamento.Sugestoes.Count > 0)
        {
            resposta.AdicionarErro("Não é possível deletar um departamento que contém sugestões cadastradas.");
            return resposta;
        }

        if (await _departamentoRepositorio.Delete(departamento)) return resposta;
        
        resposta.AdicionarErro("Erro interno do servidor.");
        return resposta;
    }
}