namespace Tethkar.Data.DTOs
{
    public class MyTicketDto
    {
        public long TicketId { get; set; }
        public long EventId { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string TicketTypeName { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string CityName { get; set; } = string.Empty;
        public string CardImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}