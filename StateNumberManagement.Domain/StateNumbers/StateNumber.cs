namespace StateNumberManagement.Domain.StateNumbers
{
    public class StateNumber
    {
        public StateNumber()
        {
            CreatedAt = DateTime.Now;
        }

        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
    }    
}
