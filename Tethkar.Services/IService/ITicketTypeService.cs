using Tethkar.Data.Models;

namespace Tethkar.Services.IService
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketType>> GetAllAsync();
        Task<TicketType?> GetByIdAsync(long id);
        Task<IEnumerable<TicketType>> GetByEventIdAsync(long eventId);
        Task<TicketType?> CreateAsync(TicketType ticketType);
        Task<TicketType?> UpdateAsync(long id, TicketType ticketType);
        Task<TicketType?> DeleteAsync(long id);
    }
}