using System.Net.Sockets;

namespace Tethkar.Data.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int CityId { get; set; }
        public int OrganizerId { get; set; }

        public City City { get; set; } = null!;
        public User Organizer { get; set; } = null!;

        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}