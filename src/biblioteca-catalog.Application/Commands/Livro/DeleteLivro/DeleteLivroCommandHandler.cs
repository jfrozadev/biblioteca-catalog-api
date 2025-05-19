using MediatR;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using biblioteca_catalog.Domain.Entities; // Pode ser necessário para encontrar a entidade antes de remover


namespace biblioteca_catalog.Application.Commands.Livro.DeleteLivro
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeleteLivroCommand, Unit>
    {
        private readonly ILivroRepository _livroRepository; // Usar a interface do repositório

        public DeleteLivroCommandHandler(ILivroRepository livroRepository) // Injetar a interface do repositório
        {
            _livroRepository = livroRepository;
        }

        public async Task<Unit> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Codl); // Buscar o livro usando o repositório

            if (livro == null)
            {
                // Aqui você pode lançar uma exceção personalizada de "Não Encontrado"
                throw new Exception($"Livro com código {request.Codl} não encontrado.");
            }

            _livroRepository.Remove(livro); // Remover o livro usando o repositório
            return Unit.Value;
        }
    }
}