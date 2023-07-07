using Mapster;
using StateNumberManagement.Application.StateNumbers.Request;
using StateNumberManagement.Application.StateNumbers.Response;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.StateNumbers;
using StateNumberManagement.Infrastructure;
using StateNumberManagement.Infrastructure.StateNumbers;

namespace StateNumberManagement.Application.StateNumbers
{
    public class StateNumberService : IStateNumberService
    {
        private readonly IStateNumberRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StateNumberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.StateNumberRepository;
        }

        public async Task<StateNumberDetails> GetDetailsOnStateNumber(string Id, CancellationToken token)
        {
            var stateNumberDetails = new StateNumberDetails();

            stateNumberDetails.StateNumber = await _repository.GetAsync(Id, token);
            var number = stateNumberDetails.StateNumber.Number;
            stateNumberDetails.StateNumberOrder = await _unitOfWork.OrderRepository.GetByNumber(number, token);
            stateNumberDetails.StateNumberReservation = await _unitOfWork.ReservationRepository.GetByNumber(number, token);

            return stateNumberDetails;
        }

        public async Task AddAsync(StateNumberRequestModel entity, CancellationToken token)
        {
            var stateNumber = entity.Adapt<StateNumber>();

            stateNumber.Id = Guid.NewGuid().ToString();

            await _repository.AddAsync(stateNumber, token);
        }

        public async Task DeleteAsync(string Id, CancellationToken token)
        {
            await _repository.DeleteAsync(Id, token);
        }

        public async Task UpdateAsync(string Id, StateNumberRequestModel entity, CancellationToken token)
        {
            var stateNumber = await _repository.GetAsync(Id, token);

            stateNumber.Number = entity.Number;

            await _repository.UpdateAsync(stateNumber, token);
        }

        public async Task<PaginatedList<StateNumber>> GetAllAsync(SearchParameters parameters, CancellationToken token)
        {
            return await _repository.GetAllAsync(parameters, token);
        }

        public async Task<StateNumber> GetAsync(string Id, CancellationToken token)
        {
            return await _repository.GetAsync(Id, token);
        }

        public async Task<bool> NumberExistsAsync(string number, CancellationToken token)
        {
            return await _repository.NumberExistsAsync(number, token);
        }

        public async Task<List<StateNumber>> GetAllAsync(CancellationToken token)
        {
            return (await _repository.GetAllAsync(token)).ToList();
        }
    }
}
