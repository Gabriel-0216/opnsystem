using Application.Commands.Requisicao;
using Application.Queries.Consulta;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugestoesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SugestoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarSugestaoRequisicao requisicao)
        {
            var result = await _mediator.Send(requisicao);
            return result.SucessoOperacao() ? Ok(result) : BadRequest(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = new ListarSugestoesConsulta();
            return Ok(await _mediator.Send(consulta));
        }

        
         
    }
}
