using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroRepository(BibliotecaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Livro?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Livros
                .Include(l => l.Livros_Autores).ThenInclude(la => la.Autor)
                .Include(l => l.Livros_Assuntos).ThenInclude(la => la.Assunto)
                .FirstOrDefaultAsync(l => l.Codl == id, cancellationToken);
        }

        public async Task<IEnumerable<Livro>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Livros
                .Include(l => l.Livros_Autores).ThenInclude(la => la.Autor)
                .Include(l => l.Livros_Assuntos).ThenInclude(la => la.Assunto)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Livro entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Livros.AddAsync(entity, cancellationToken);
        }

        public void Update(Livro entity)
        {
            _dbContext.Livros.Update(entity);
        }

        public void Remove(Livro entity)
        {
            _dbContext.Livros.Remove(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
