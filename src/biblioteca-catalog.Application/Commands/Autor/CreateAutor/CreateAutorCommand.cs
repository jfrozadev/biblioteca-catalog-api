using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public record CreateAutorCommand : IRequest<AutorDto>
    {
        public string Nome { get; set; }
    }
}