using biblioteca_catalog.Application.Commands.Assunto.CreateAssunto;
using biblioteca_catalog.Application.Commands.Assunto.DeleteAssunto;
using biblioteca_catalog.Application.Commands.Assunto.UpdateAssunto;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace biblioteca_catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssuntosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAssuntoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateAssuntoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAssuntoCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // Adicionar métodos para consultas (Queries) conforme necessário
        // Exemplo:
        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get(int id)
        // {
        //     var query = new GetAssuntoByIdQuery(id);
        //     var result = await _mediator.Send(query);
        //     return Ok(result);
        // }
    }
}