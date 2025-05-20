using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(biblioteca_catalogDbContext context) : base(context)
        {
        }

        public async Task<Livro?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Livros
                .Include(l => l.LivroAutores)
                    .ThenInclude(la => la.Autor)
                .Include(l => l.LivroAssuntos)
                    .ThenInclude(la => la.Assunto)
                .SingleOrDefaultAsync(l => l.Codl == id, cancellationToken);
        }

        public async Task<IEnumerable<Livro>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Livros
                .Include(l => l.LivroAutores)
                    .ThenInclude(la => la.Autor)
                .Include(l => l.LivroAssuntos)
                    .ThenInclude(la => la.Assunto)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Livro entity, CancellationToken cancellationToken = default)
        {
            await _context.Livros.AddAsync(entity, cancellationToken);
        }

        public void Update(Livro entity)
        {
            _context.Livros.Update(entity);
        }

        public void Remove(Livro entity)
        {
            _context.Livros.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
