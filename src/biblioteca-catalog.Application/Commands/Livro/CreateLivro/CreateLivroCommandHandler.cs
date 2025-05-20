using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;

namespace biblioteca_catalog.Application.Commands.Livro.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository;

        public CreateLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro
            {
                Titulo = request.Titulo,
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao
            };

            await _livroRepository.AddAsync(livro, cancellationToken);
            await _livroRepository.SaveChangesAsync(cancellationToken);

            return livro.Codl;
        }
    }
}
