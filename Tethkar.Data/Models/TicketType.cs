using System.ComponentModel.DataAnnotations.Schema;

namespace Tethkar.Data.Models
{
    public class TicketType
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public long EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event? Event { get; set; }
    }
}