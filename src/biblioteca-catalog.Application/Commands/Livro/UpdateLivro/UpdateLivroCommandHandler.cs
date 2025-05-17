using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Interfaces; // Adicionar este using
using biblioteca_catalog.Domain.Entities; // Pode ser necessário para encontrar a entidade antes de atualizar

namespace biblioteca_catalog.Application.Commands.Livro.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, Unit>
    {
        private readonly ILivroRepository _livroRepository; // Usar a interface do repositório

        public UpdateLivroCommandHandler(ILivroRepository livroRepository) // Injetar a interface do repositório
        {
            _livroRepository = livroRepository;
        }

        public async Task<Unit> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Codl); // Buscar o livro usando o repositório

            if (livro == null)
            {
                throw new Exception($"Livro com Codl {request.Codl} não encontrado."); // Consider creating a specific NotFoundException
            }

            livro.Titulo = request.Titulo;
            livro.Editora = request.Editora;
            livro.Edicao = request.Edicao;
            livro.AnoPublicacao = request.AnoPublicacao;

            _livroRepository.Update(livro); // Atualizar o livro usando o repositório

            return Unit.Value;
        }
    }
}