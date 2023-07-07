using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Infrastructure.StateNumbers
{
    public interface IStateNumberRepository : IBaseRepository<StateNumber>
    {
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumber>> GetAllAsync(SearchParameters parameters, CancellationToken token);
    }
}
