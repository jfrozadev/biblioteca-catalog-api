using biblioteca_catalog.Application.DTOs.EntityDtos;
using MediatR;

namespace biblioteca_catalog.Application.Commands.Assunto.UpdateAssunto
{
    public record UpdateAssuntoCommand(int Id, string Descricao) : IRequest<AssuntoDto>;
}
