using System.Net.Sockets;

namespace Tethkar.Data.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int OrderItemId { get; set; }
        public int TicketTypeId { get; set; }
        public int BuyerUserId { get; set; }

        public DateTime PurchasedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        public OrderItem OrderItem { get; set; } = null!;
        public TicketType TicketType { get; set; } = null!;
        public User Buyer { get; set; } = null!;
    }
}