namespace StateNumberManagement.Domain.StateNumberOrders
{
    public class StateNumberOrder
    {
        public StateNumberOrder()
        {
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
