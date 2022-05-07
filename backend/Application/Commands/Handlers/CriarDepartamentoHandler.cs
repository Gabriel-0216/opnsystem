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

        try
        {
            await _departamentoRepositorio.Add(departamento);
            return resposta;
        }
        catch (SqlException ex)
        {
            resposta.AdicionarErro("Erro interno do servidor.");
            return resposta;
        }
        
    }
}