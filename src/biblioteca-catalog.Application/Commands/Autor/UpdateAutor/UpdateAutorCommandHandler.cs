using MediatR;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using System.Threading;
using System.Threading.Tasks;

namespace biblioteca_catalog.Application.Commands.Autor.UpdateAutor
{
    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, Unit>
    {
        private readonly IAutorRepository _autorRepository; // Usar a interface do repositório

        public UpdateAutorCommandHandler(IAutorRepository autorRepository) // Injetar a interface do repositório
        {
            _autorRepository = autorRepository;
        }

        public async Task<Unit> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetByIdAsync(request.CodAu); // Buscar o autor usando o repositório

            if (autor == null)
                throw new KeyNotFoundException($"Autor com Id {request.CodAu} não encontrado.");

            autor.Nome = request.Nome;

            _autorRepository.Update(autor); // Atualizar o autor usando o repositório

            return Unit.Value;
        }
    }
}