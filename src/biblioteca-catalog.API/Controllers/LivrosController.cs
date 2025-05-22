using MediatR;
using Microsoft.AspNetCore.Mvc;
using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using biblioteca_catalog.Application.Commands.Livro.UpdateLivro;
using biblioteca_catalog.Application.Commands.Livro.DeleteLivro;
using biblioteca_catalog.Application.Queries.Livro.GetLivroById;
using biblioteca_catalog.Application.Queries.Livro.GetAllLivros;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetAllLivros()
        {
            var query = new GetAllLivrosQuery();
            var livros = await _mediator.Send(query);
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDto>> GetLivroById(int id)
        {
            var query = new GetLivroByIdQuery(id);
            var livro = await _mediator.Send(query);
            return livro != null ? Ok(livro) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateLivro([FromBody] CreateLivroCommand command)
        {
            var livroId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLivroById), new { id = livroId }, livroId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivro(int id, [FromBody] UpdateLivroCommand command)
        {
            if (id != command.Codl)
            {
                return BadRequest();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var command = new DeleteLivroCommand(id);
            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }
    }
}
