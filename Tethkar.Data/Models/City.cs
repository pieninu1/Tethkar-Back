using Microsoft.Extensions.Logging;

namespace Tethkar.Data.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}