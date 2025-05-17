using biblioteca_catalog.Application.Commands.Livro.CreateLivro;
using biblioteca_catalog.Infrastructure.Data.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Application.Commands.Livro.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Domain.Entities.Livro
            {
                Titulo = request.Titulo,
                Editora = request.Editora,
                Edicao = request.Edicao,
                AnoPublicacao = request.AnoPublicacao
            };

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync(cancellationToken);

            return livro.Codl;
        }
    }
}