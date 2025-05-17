using MediatR;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, int>
    {
 private readonly IAutorRepository _autorRepository; // Usar a interface do repositório

        public CreateAutorCommandHandler(IAutorRepository autorRepository) // Injetar a interface do repositório
        {
 _autorRepository = autorRepository;
        }

        public async Task<int> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = new Autor
            {
                Nome = request.Nome
            };

 await _autorRepository.AddAsync(autor); // Usar o método do repositório

            return autor.CodAu;
        }
    }
}