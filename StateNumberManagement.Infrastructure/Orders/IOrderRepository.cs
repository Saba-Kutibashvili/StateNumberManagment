﻿using StateNumberManagement.Domain;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumberOrders;

namespace StateNumberManagement.Infrastructure.Orders
{
    public interface IOrderRepository : IBaseRepository<StateNumberOrder>
    {
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumberOrder>> GetAllAsync(SearchParameters parameters, CancellationToken token);
        Task<StateNumberOrder> GetByNumber(string number, CancellationToken token);
    }
}
