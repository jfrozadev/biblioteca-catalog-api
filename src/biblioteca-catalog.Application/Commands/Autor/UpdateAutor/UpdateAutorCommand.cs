using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Commands.Autor.UpdateAutor
{
    public record UpdateAutorCommand : IRequest<AutorDto>
    {
        public int CodAu { get; set; }
        public string Nome { get; init; }
    }
}