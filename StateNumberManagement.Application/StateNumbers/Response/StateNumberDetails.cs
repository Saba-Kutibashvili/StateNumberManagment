using StateNumberManagement.Domain.Reservations;
using StateNumberManagement.Domain.StateNumberOrders;
using StateNumberManagement.Domain.StateNumbers;

namespace StateNumberManagement.Application.StateNumbers.Response
{
    public class StateNumberDetails
    {
        public StateNumber StateNumber { get; set; }
        public StateNumberReservation StateNumberReservation { get; set; }
        public StateNumberOrder StateNumberOrder { get; set; }
    }
}
