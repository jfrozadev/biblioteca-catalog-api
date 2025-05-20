using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;
using System.Collections.Generic;

namespace biblioteca_catalog.Application.Queries.Assunto.GetAllAssuntos
{
    public record GetAllAssuntosQuery : IRequest<IEnumerable<AssuntoDto>>;
}