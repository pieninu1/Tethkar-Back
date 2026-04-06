namespace Tethkar.Data.Models
{
    public class Event
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long CityId { get; set; }
        public string OrganizerId { get; set; } = string.Empty;

        public City City { get; set; } = null!;
        public ApplicationUser Organizer { get; set; } = null!;

        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}