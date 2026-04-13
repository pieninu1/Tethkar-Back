using System.Text.Json.Serialization;

namespace Tethkar.Data.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}