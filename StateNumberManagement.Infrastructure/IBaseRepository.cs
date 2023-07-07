using StateNumberManagement.Domain;

namespace StateNumberManagement.Infrastructure
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity, CancellationToken token);
        Task<T> GetAsync(string Id, CancellationToken token);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);
        Task UpdateAsync(T entity, CancellationToken token);
        Task DeleteAsync(string Id, CancellationToken token);
    }
}
