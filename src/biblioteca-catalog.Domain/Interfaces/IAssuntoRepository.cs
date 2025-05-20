using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Domain.Interfaces
{
    public interface IAssuntoRepository : IRepository<Assunto>
    {
        Task<IEnumerable<Assunto>> GetAssuntosAsync(CancellationToken cancellationToken = default);
    }
}
