namespace Tethkar.Data.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public long OrderItemId { get; set; }
        public long TicketTypeId { get; set; }
        public string BuyerUserId { get; set; } = string.Empty;
        public DateTime PurchasedAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public OrderItem OrderItem { get; set; } = null!;
        public TicketType TicketType { get; set; } = null!;
        public ApplicationUser Buyer { get; set; } = null!;
    }
}