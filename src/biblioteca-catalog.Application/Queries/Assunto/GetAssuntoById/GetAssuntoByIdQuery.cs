using MediatR;
using biblioteca_catalog.Application.DTOs.EntityDtos;

namespace biblioteca_catalog.Application.Queries.Assunto.GetAssuntoById
{
    public record GetAssuntoByIdQuery(int Id) : IRequest<AssuntoDto>;
}