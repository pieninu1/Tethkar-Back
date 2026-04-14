using System.ComponentModel.DataAnnotations.Schema;

namespace Tethkar.Data.Models
{
    public class UserFavorite
    {
        public long Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }

        public long EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event? Event { get; set; }
    }
}