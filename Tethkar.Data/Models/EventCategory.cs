namespace Tethkar.Data.Models
{
    public class EventCategory
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long CategoryId { get; set; }
        public Event Event { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}