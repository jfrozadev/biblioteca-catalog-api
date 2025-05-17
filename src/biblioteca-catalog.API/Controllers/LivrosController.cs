using MediatR;
using Microsoft.AspNetCore.Mvc;
using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using biblioteca_catalog.Application.Commands.Livro.UpdateLivro;
using biblioteca_catalog.Application.Commands.Livro.DeleteLivro;
using biblioteca_catalog.Application.Queries.Livro.GetLivroById;
using biblioteca_catalog.Application.Queries.Livro.GetAllLivros;
using biblioteca_catalog.Application.DTOs.EntityDtos; // Verifique se o namespace está correto

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLivroCommand command)
        {
            var livroId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = livroId }, livroId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLivroCommand command)
        {
            if (id != command.Codl)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLivroCommand { Codl = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDto>> GetById(int id)
        {
            var query = new GetLivroByIdQuery { Codl = id };
            var livro = await _mediator.Send(query);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        [HttpGet]
        public async Task<ActionResult<List<LivroDto>>> GetAll()
        {
            var query = new GetAllLivrosQuery();
            var livros = await _mediator.Send(query);
            return Ok(livros);
        }
    }
}