namespace Tethkar.Data.Models
{
    public class PaymentMethod
    {
        public long Id { get; set; }
        public string MethodName { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}