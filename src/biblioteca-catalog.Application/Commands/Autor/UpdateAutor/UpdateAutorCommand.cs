csharp
using MediatR;

namespace biblioteca_catalog.Application.Commands.Autor.UpdateAutor
{
    public class UpdateAutorCommand : IRequest<Unit>
    {
        public int CodAu { get; set; }
        public string Nome { get; set; }
    }
}