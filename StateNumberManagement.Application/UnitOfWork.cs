using StateNumberManagement.Application;
using StateNumberManagement.Infrastructure.Orders;
using StateNumberManagement.Infrastructure.Reservations;
using StateNumberManagement.Infrastructure.StateNumbers;
using StateNumberManagement.Persistance.Context;

namespace StateNumberManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public StateNumberManagementContext Context { get; }

        public readonly IStateNumberRepository _stateNumberRepository;

        public readonly IReservationRepository _reservationRepository;

        public readonly IOrderRepository _orderRepository;

        public UnitOfWork(StateNumberManagementContext dbContext)
        {
            Context = dbContext;

            _stateNumberRepository = new StateNumberRepository(Context);
            _reservationRepository = new ReservationRepository(Context);
            _orderRepository = new OrderRepository(Context);
        }

        public IStateNumberRepository StateNumberRepository { get => _stateNumberRepository; }

        public IReservationRepository ReservationRepository { get => _reservationRepository; }

        public IOrderRepository OrderRepository { get => _orderRepository; }

        public async Task SaveAsync(CancellationToken token)
            => await Context.SaveChangesAsync(token);

        public async Task RollbackAsync()
            => await Context.DisposeAsync();
    }
}
