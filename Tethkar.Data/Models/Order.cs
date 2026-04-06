namespace Tethkar.Data.Models
{
    public class Order
    {
        public long Id { get; set; }

        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Relationships (add later)
        public string BuyerUserId { get; set; } = string.Empty;
        public ApplicationUser Buyer { get; set; } = null!;

         public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
         public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}