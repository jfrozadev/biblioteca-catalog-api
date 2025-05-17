csharp
using MediatR;

namespace biblioteca_catalog.Application.Commands.Livro.DeleteLivro
{
    public class DeleteLivroCommand : IRequest<Unit>
    {
        public int Codl { get; set; }
    }
}