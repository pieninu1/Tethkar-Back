using System.Net.Sockets;

namespace Tethkar.Data.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}