
namespace Tethkar.Data.DTOs
{
    public class BookTicketDto
    {
        public long TicketTypeId { get; set; }
        public DateTime EventDate { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
