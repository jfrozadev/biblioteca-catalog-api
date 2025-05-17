using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Infrastructure.Data.Context; // Assuming your DbContext is here

namespace biblioteca_catalog.Application.Commands.Livro.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, Unit>
    {
        private readonly ApplicationDbContext _context; // Assuming your DbContext is named ApplicationDbContext

        public UpdateLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Codl == request.Codl, cancellationToken);

            if (livro == null)
            {
                // Throw a custom exception if the book is not found
                throw new Exception($"Livro com Codl {request.Codl} não encontrado."); // Consider creating a specific NotFoundException
            }

            livro.Titulo = request.Titulo;
            livro.Editora = request.Editora;
            livro.Edicao = request.Edicao;
            livro.AnoPublicacao = request.AnoPublicacao;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}