using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public LivroRepository(biblioteca_catalogDbContext context) : base(context)
        {
        }

        // Implementar métodos específicos para Livro, se houver, ou apenas usar os métodos da base
    }
}