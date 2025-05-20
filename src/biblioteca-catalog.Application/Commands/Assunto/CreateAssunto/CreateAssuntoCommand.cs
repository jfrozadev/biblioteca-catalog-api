csharp
using biblioteca_catalog.Application.DTOs.EntityDtos;
using MediatR;

namespace biblioteca_catalog.Application.Commands.Assunto.CreateAssunto
{
    public record CreateAssuntoCommand(string Descricao) : IRequest<AssuntoDto>;
}