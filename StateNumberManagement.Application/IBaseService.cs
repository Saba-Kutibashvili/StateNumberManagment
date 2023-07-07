using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Application
{
    public interface IBaseService<T>
    {
        Task<T> GetAsync(string Id, CancellationToken token);
        Task<List<T>> GetAllAsync(CancellationToken token);
        Task DeleteAsync(string Id, CancellationToken token);
    }
}
