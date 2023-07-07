using StateNumberManagement.Infrastructure.Orders;
using StateNumberManagement.Infrastructure.Reservations;
using StateNumberManagement.Infrastructure.StateNumbers;

namespace StateNumberManagement.Application
{
    public interface IUnitOfWork
    {
        IStateNumberRepository StateNumberRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task SaveAsync(CancellationToken token);
        Task RollbackAsync();
    }
}
