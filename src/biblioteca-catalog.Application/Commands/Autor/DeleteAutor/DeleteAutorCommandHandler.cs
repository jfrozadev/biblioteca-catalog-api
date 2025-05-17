csharp
using MediatR;
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Infrastructure.Data.Context; // Verifique o namespace correto

namespace biblioteca_catalog.Application.Commands.Autor.DeleteAutor
{
    public class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand, Unit>
    {
        private readonly biblioteca_catalogDbContext _context;

        public DeleteAutorCommandHandler(biblioteca_catalogDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _context.Autores.FindAsync(new object[] { request.CodAu }, cancellationToken);

            if (autor == null)
            {
                // Considere criar uma exceção customizada para "Não Encontrado"
                throw new KeyNotFoundException($"Autor com CodAu {request.CodAu} não encontrado.");
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}