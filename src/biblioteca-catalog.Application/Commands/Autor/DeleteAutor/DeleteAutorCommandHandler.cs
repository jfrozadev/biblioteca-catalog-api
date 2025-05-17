using MediatR;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Entities; // Pode ser necessário para encontrar a entidade antes de remover
using System.Collections.Generic; // Para KeyNotFoundException

namespace biblioteca_catalog.Application.Commands.Autor.DeleteAutor
{
    public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand, Unit>
    {
        private readonly IAutorRepository _autorRepository; // Usar a interface do repositório

        public DeleteAutorCommandHandler(IAutorRepository autorRepository) // Injetar a interface do repositório
        {
            _autorRepository = autorRepository;
        }

        public async Task<Unit> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.GetByIdAsync(request.CodAu); // Buscar o autor usando o repositório

            if (autor == null)
 throw new KeyNotFoundException($"Autor com CodAu {request.CodAu} não encontrado.");

            _autorRepository.Remove(autor); // Remover o autor usando o repositório

            return Unit.Value;
        }
    }
}