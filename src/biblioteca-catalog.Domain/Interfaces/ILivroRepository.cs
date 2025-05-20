using biblioteca_catalog.Domain.Entities;

namespace biblioteca_catalog.Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<Livro?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Livro>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Livro entity, CancellationToken cancellationToken = default);
        void Update(Livro entity);
        void Remove(Livro entity);
    }
}
