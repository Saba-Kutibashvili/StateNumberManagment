using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Application.StateNumbers
{
    public interface IStateNumberService : IBaseService<StateNumber>
    {
        Task AddAsync(StateNumberRequestModel entity, CancellationToken token);
        Task UpdateAsync(string Id, StateNumberRequestModel entity, CancellationToken token);
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumber>> GetAllAsync(SearchParameters parameters, CancellationToken token);
    }
}
