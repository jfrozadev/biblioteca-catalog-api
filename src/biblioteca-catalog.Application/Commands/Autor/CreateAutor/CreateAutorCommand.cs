using MediatR;

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public class CreateAutorCommand : IRequest<int>
    {
        public string Nome { get; set; }
    }
}