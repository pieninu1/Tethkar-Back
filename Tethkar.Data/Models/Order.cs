using System.ComponentModel.DataAnnotations.Schema;
using Tethkar.Data.Enums;

namespace Tethkar.Data.Models
{
    public class Order
    {
        public long Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatusEnum Status { get; set; }

        public string BuyerUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(BuyerUserId))]
        public ApplicationUser? Buyer { get; set; }

         public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
         public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}