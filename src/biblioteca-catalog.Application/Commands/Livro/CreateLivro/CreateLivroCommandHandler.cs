using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces; // Adicionado using para a interface do repositório

namespace biblioteca_catalog.Application.Commands.Livro.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository; // Substituído DbContext pela interface do repositório

        public CreateLivroCommandHandler(ILivroRepository livroRepository) // Injetado a interface do repositório
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Domain.Entities.Livro
 // Removido 'Domain.Entities.' pois o using para a entidade Livro já existe.
            {
                Titulo = request.Titulo,
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao
            };

 await _livroRepository.AddAsync(livro); // Utilizado o método AddAsync do repositório
            return livro.Codl;
        }
    }
}