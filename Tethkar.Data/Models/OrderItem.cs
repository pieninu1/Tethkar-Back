namespace Tethkar.Data.Models
{
    public class OrderItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Relationships
         public long OrderId { get; set; }
         public long TicketTypeId { get; set; }
         public Order Order { get; set; } = null!;
         public TicketType TicketType { get; set; } = null!;

         public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}