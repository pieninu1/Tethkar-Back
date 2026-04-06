using System.ComponentModel.DataAnnotations.Schema;
using Tethkar.Data.Enums;

namespace Tethkar.Data.Models
{
    public class Ticket
    {
        public long Id { get; set; }
        public DateTime PurchasedAt { get; set; }
        public TicketStatusEnum Status { get; set; }

        public long TicketTypeId { get; set; }
        [ForeignKey(nameof(TicketTypeId))]
        public TicketType? TicketType { get; set; }

        public string BuyerUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(BuyerUserId))]
        public ApplicationUser? Buyer { get; set; }
    }
}