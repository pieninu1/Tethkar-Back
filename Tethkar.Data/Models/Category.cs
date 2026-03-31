using System.ComponentModel.DataAnnotations.Schema;

namespace Tethkar.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
    }
}