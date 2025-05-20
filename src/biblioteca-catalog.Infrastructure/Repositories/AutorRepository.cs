using biblioteca_catalog.Domain.Entities;
using biblioteca_catalog.Domain.Interfaces;
using biblioteca_catalog.Infrastructure.Data.Context;

namespace biblioteca_catalog.Infrastructure.Repositories
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(BibliotecaDbContext context) : base(context)
        {
        }
    }
}
