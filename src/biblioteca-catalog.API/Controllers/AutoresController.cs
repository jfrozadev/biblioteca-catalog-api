using biblioteca_catalog.Application.Commands.Autor.CreateAutor;
using biblioteca_catalog.Application.Commands.Autor.DeleteAutor;
using biblioteca_catalog.Application.Commands.Autor.UpdateAutor;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using biblioteca_catalog.Application.Queries.Autor.GetAutorById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace biblioteca_catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            var query = new GetAutorByIdQuery { Id = id };
            var autor = await _mediator.Send(query);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // POST: api/Autores
        [HttpPost]
        public async Task<ActionResult<AutorDto>> PostAutor(CreateAutorCommand command)
        {
            var autor = await _mediator.Send(command);
            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        // PUT: api/Autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, UpdateAutorCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var command = new DeleteAutorCommand { Id = id };
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}