using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumberOrders;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Application.Orders
{
    public interface IOrderService : IBaseService<StateNumberOrder>
    {
        Task AddAsync(StateNumberRequestModel entity, CancellationToken token);
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumberOrder>> GetAllAsync(SearchParameters parameters, CancellationToken token);
    }
}
