namespace Tethkar.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }

        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime PaidAt { get; set; }
        public string ProviderName { get; set; } = string.Empty;

        public Order Order { get; set; } = null!;
        public PaymentMethod PaymentMethod { get; set; } = null!;
    }
}