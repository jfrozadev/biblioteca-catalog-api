using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(biblioteca_catalogDbContext context) : base(context)
        {
        }

        // Implementar métodos específicos para Autor, se houver, ou apenas usar os métodos da base
    }
}