using StateNumberManagement.Domain;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Infrastructure.Reservations
{
    public interface IReservationRepository : IBaseRepository<StateNumberReservation>
    {
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumberReservation>> GetAllAsync(SearchParameters parameters, CancellationToken token);
    }
}
