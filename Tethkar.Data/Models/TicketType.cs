namespace Tethkar.Data.Models
{
    public class TicketType
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public long EventId { get; set; }
        public Event Event { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}