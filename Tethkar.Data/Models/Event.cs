using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }

        public string OrganizerId { get; set; } = string.Empty;
        [ForeignKey(nameof(OrganizerId))]
        public ApplicationUser? Organizer { get; set; }

        public long CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}