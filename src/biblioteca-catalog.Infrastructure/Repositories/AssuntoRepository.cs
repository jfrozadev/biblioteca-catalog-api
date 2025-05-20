using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class AssuntoRepository : RepositoryBase<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(BibliotecaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Assunto>> GetAssuntosAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Assuntos.ToListAsync(cancellationToken);
        }
    }
}
