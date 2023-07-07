namespace StateNumberManagement.Domain.Reservations
{
    public class StateNumberReservation
    {
        public StateNumberReservation()
        {
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set;}
    }
}
