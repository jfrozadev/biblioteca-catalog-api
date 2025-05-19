using MediatR;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Autor.CreateAutor
{
    public class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, int>
    {
        private readonly IAutorRepository _autorRepository;

        public CreateAutorCommandHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<int> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            // Use o namespace completo para evitar ambiguidades
            var autor = new biblioteca_catalog.Domain.Entities.Autor
            {
                Nome = request.Nome
            };

            await _autorRepository.AddAsync(autor);

            return autor.CodAu;
        }
    }
}
