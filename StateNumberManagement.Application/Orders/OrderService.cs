using Mapster;
using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumberOrders;
using StateNumberManagement.Domain.StateNumbers;
using StateNumberManagement.Infrastructure.Orders;

namespace StateNumberManagement.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(StateNumberRequestModel entity, CancellationToken token)
        {
            var stateNumber = entity.Adapt<StateNumberOrder>();

            stateNumber.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(stateNumber, token);
        }

        public async Task DeleteAsync(string Id, CancellationToken token)
        {
            await _repository.DeleteAsync(Id, token);
        }

        public async Task<List<StateNumberOrder>> GetAllAsync(CancellationToken token)
        {
            return (await _repository.GetAllAsync(token)).ToList();
        }

        public async Task<StateNumberOrder> GetAsync(string Id, CancellationToken token)
        {
            return await _repository.GetAsync(Id, token);
        }

        public async Task<bool> NumberExistsAsync(string number, CancellationToken token)
        {
            return await _repository.NumberExistsAsync(number, token);
        }

        public async Task<PaginatedList<StateNumberOrder>> GetAllAsync(SearchParameters parameters, CancellationToken token)
        {
            return await _repository.GetAllAsync(parameters, token);
        }
    }
}
