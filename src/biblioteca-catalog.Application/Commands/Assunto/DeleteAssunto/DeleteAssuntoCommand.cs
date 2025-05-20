using MediatR;

namespace biblioteca_catalog.Application.Commands.Assunto.DeleteAssunto
{
    public record DeleteAssuntoCommand(int Id) : IRequest<Unit>;
}