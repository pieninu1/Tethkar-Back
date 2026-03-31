using Microsoft.Extensions.Logging;

namespace Tethkar.Data.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}