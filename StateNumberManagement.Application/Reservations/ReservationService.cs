using Mapster;
using StateNumberManagement.Application.StateNumberReservations.Request;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Infrastructure.Reservations;

namespace StateNumberManagement.Application.StateNumberReservations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;

        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(StateNumberReservationRequestModel entity, CancellationToken token)
        {
            var stateNumber = entity.Adapt<StateNumberReservation>();

            stateNumber.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(stateNumber, token);
        }

        public async Task DeleteAsync(string Id, CancellationToken token)
        {
            await _repository.DeleteAsync(Id, token);
        }

        public async Task<List<StateNumberReservation>> GetAllAsync(CancellationToken token)
        {
            return (await _repository.GetAllAsync(token)).ToList();
        }

        public async Task<StateNumberReservation> GetAsync(string Id, CancellationToken token)
        {
            return await _repository.GetAsync(Id, token);
        }

        public async Task<bool> NumberExistsAsync(string number, CancellationToken token)
        {
            return await _repository.NumberExistsAsync(number, token);
        }

        public async Task<PaginatedList<StateNumberReservation>> GetAllAsync(SearchParameters parameters, CancellationToken token)
        {
            return await _repository.GetAllAsync(parameters, token);
        }
    }
}
