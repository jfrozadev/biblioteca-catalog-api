using biblioteca_catalog.Application.Commands.Assunto.CreateAssunto;
using biblioteca_catalog.Application.Commands.Assunto.DeleteAssunto;
using biblioteca_catalog.Application.Commands.Assunto.UpdateAssunto;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Application.Queries.Assunto.GetAllAssuntos;
using biblioteca_catalog.Application.Queries.Assunto.GetAssuntoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> GetAllAssuntos()
        {
            var query = new GetAllAssuntosQuery();
            var assuntos = await _mediator.Send(query);
            return Ok(assuntos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssuntoDto>> GetAssuntoById(int id)
        {
            var query = new GetAssuntoByIdQuery(id);
            var assunto = await _mediator.Send(query);
            return assunto != null ? Ok(assunto) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAssunto([FromBody] CreateAssuntoCommand command)
        {
            var assuntoId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAssuntoById), new { id = assuntoId }, assuntoId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssunto(int id, [FromBody] UpdateAssuntoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var assunto = await _mediator.Send(command);
            return assunto != null ? Ok(assunto) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssunto(int id)
        {
            var command = new DeleteAssuntoCommand(id);
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
