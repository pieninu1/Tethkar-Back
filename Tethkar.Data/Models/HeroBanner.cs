namespace Tethkar.Data.Models
{
    public class HeroBanner
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonLink { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}