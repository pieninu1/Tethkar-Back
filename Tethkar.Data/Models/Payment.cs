namespace Tethkar.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public string Status { get; set; } = string.Empty;

        // Relationships
        public long OrderId { get; set; }
        public long PaymentMethodId { get; set; }
        public Order Order { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}