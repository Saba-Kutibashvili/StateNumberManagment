using Microsoft.EntityFrameworkCore;
using StateNumberManagement.Domain;
using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumbers;
using static StateNumberManagement.Domain.SearchParameters;

namespace StateNumberManagement.Infrastructure.Reservations
{
    public class ReservationRepository : BaseRepository<StateNumberReservation>, IReservationRepository
    {
        public ReservationRepository(DbContext context) : base(context)
        {
        }

        public async override Task<StateNumberReservation> GetAsync(string Id, CancellationToken token)
        {
            return await Table.SingleOrDefaultAsync(x => x.Id == Id, token);
        }

        public async Task<bool> NumberExistsAsync(string number, CancellationToken token)
        {
            return await Table.FirstOrDefaultAsync(x => x.Number == number, token) != null;
        }

        public async Task<PaginatedList<StateNumberReservation>> GetAllAsync(SearchParameters parameters, CancellationToken token)
        {
            var results = await base.GetAllAsync(token);

            if (!String.IsNullOrEmpty(parameters.SearchString))
            {
                results = results.Where(x => x.Number.Contains(parameters.SearchString));
            }

            switch (parameters.SortOrder)
            {
                case OrderBy.AphabeticalByNumber:
                    results = results.OrderBy(x => x.Number);
                    break;
                case OrderBy.DateAcending:
                    results = results.OrderBy(x => x.CreatedAt);
                    break;
                case OrderBy.DateDescending:
                    results = results.OrderByDescending(x => x.CreatedAt);
                    break;
                default:
                    break;
            }

            return await PaginatedList<StateNumberReservation>.CreateAsync(results, parameters.PageIndex, 2);
        }
    }
}
