using Application.Commands.Requisicao;
using Application.Commands.Respostas;
using Dominio.DAL.Repositorios.DepartamentoRepositorio;
using Dominio.Entidades;
using MediatR;
using Microsoft.Data.SqlClient;

namespace Application.Commands.Handlers;

public class CriarDepartamentoHandler : IRequestHandler<CriarDepartamentoRequisicao, CriarDepartamentoResposta>
{
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public CriarDepartamentoHandler(IDepartamentoRepositorio departamentoRepositorio)
    {
        _departamentoRepositorio = departamentoRepositorio;
    }

    public async Task<CriarDepartamentoResposta> Handle(CriarDepartamentoRequisicao request, CancellationToken cancellationToken)
    {
        var resposta = new CriarDepartamentoResposta();
        var departamento = new Departamento(request.Nome);
        if (!departamento.IsValid)
        {
           resposta.AdicionarErros(departamento.RetornarNotificacoesString());
           return resposta;
        }
        if (await _departamentoRepositorio.Add(departamento)) return resposta;

        resposta.AdicionarErro("erro interno do servidor.");
        return resposta;
  
        
    }
}