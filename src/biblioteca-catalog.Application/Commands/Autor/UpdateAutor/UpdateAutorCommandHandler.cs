csharp
using MediatR;
using Microsoft.EntityFrameworkCore;
using biblioteca_catalog.Infrastructure.Data.Context; // Verifique o namespace do seu DbContext

namespace biblioteca_catalog.Application.Commands.Autor.UpdateAutor
{
    public class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, Unit>
    {
        private readonly biblioteca_catalogDbContext _context;

        public UpdateAutorCommandHandler(biblioteca_catalogDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await _context.Autores.FindAsync(new object[] { request.CodAu }, cancellationToken);

            if (autor == null)
            {
                // Considere usar uma exceção customizada da camada de aplicação
                throw new KeyNotFoundException($"Autor com Id {request.CodAu} não encontrado.");
            }

            autor.Nome = request.Nome;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}