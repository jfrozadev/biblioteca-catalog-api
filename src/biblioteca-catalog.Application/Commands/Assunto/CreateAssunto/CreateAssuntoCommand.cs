using MediatR;

namespace biblioteca_catalog.Application.Commands.Assunto.CreateAssunto
{
    public record CreateAssuntoCommand(string Nome, string Descricao) : IRequest<int>;
}
