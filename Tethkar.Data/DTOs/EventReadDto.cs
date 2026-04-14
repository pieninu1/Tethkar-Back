namespace Tethkar.Data.DTOs.Event
{
    public class EventReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CardImageUrl { get; set; } = string.Empty;
        public string DetailsImageUrl1 { get; set; } = string.Empty;
        public string DetailsImageUrl2 { get; set; } = string.Empty;
        public string TermsAndConditions { get; set; } = string.Empty;

        public long CityId { get; set; }
        public string CityName { get; set; } = string.Empty;

        public long CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public decimal? LowestTicketPrice { get; set; }
    }
}