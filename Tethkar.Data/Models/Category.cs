namespace Tethkar.Data.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    //public ICollection<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
}