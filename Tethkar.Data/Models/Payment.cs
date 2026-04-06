using System.ComponentModel.DataAnnotations.Schema;
using Tethkar.Data.Enums;

namespace Tethkar.Data.Models
{
    public class Payment
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
        public PaymentStatusEnum Status { get; set; }

        public long PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? PaymentMethod { get; set; }

        public long OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
    }
}