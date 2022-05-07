using Application.Commands.Requisicao;
using Application.Queries.Consulta;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarDepartamentoRequisicao request)
        {
            var result = await _mediator.Send(request);
            return result.SucessoOperacao() ? Ok(result) : BadRequest(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Listar([FromHeader] bool incluirSugestoes = false)
        {
            var listarDepartamentosConsulta = new ListarDepartamentosConsulta(incluirSugestoes);
            var resultado = await _mediator.Send(listarDepartamentosConsulta);
            return Ok(resultado);
        }
        [HttpDelete]
        [Route("/api/Departamentos/id/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletarComando = new DeletarDepartamentoRequisicao(id);
            var resultado = await _mediator.Send(deletarComando);
            return resultado.SucessoOperacao() ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPut]
        [Route("/api/Departamentos/id/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id,
            [FromBody] AtualizarDepartamentoRequisicao requisicao)
        {
            requisicao.SetId(id);
            var resultado = await _mediator.Send(requisicao);
            return resultado.SucessoOperacao() ? Ok() : BadRequest();
        }

    }
}
