csharp
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using biblioteca_catalog.Infrastructure.Data.Context; // Assumindo que seu DbContext está aqui

namespace biblioteca_catalog.Application.Commands.Livro.DeleteLivro
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeleteLivroCommand, Unit>
    {
        private readonly ApplicationDbContext _context; // Assumindo o nome ApplicationDbContext

        public DeleteLivroCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _context.Livros
                .FirstOrDefaultAsync(l => l.Codl == request.Codl, cancellationToken);

            if (livro == null)
            {
                // Aqui você pode lançar uma exceção personalizada de "Não Encontrado"
                throw new Exception($"Livro com código {request.Codl} não encontrado.");
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}