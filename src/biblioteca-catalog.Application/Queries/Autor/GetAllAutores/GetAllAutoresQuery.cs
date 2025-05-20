using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using System.Collections.Generic;

namespace biblioteca_catalog.Application.Queries.Autor.GetAllAutores
{
    public record GetAllAutoresQuery : IRequest<IEnumerable<AutorDto>>;
}