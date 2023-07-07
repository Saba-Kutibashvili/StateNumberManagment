using StateNumberManagement.Application.StateNumberReservations.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Application.StateNumberReservations
{
    public interface IReservationService : IBaseService<StateNumberReservation>
    {
        Task AddAsync(StateNumberReservationRequestModel entity, CancellationToken token);
        Task<bool> NumberExistsAsync(string number, CancellationToken token);
        Task<PaginatedList<StateNumberReservation>> GetAllAsync(SearchParameters parameters, CancellationToken token);
    }
}
