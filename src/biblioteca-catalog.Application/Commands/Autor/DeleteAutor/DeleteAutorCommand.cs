using MediatR;

namespace biblioteca_catalog.Application.Commands.Autor.DeleteAutor
{
    public class DeleteAutorCommand : IRequest<Unit>
    {
        public int CodAu { get; set; }
    }
}