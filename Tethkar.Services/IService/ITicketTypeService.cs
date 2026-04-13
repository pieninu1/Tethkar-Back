using Tethkar.Data.DTOs;
using Tethkar.Data.Models;

namespace Tethkar.Services.IService
{
    public interface ITicketTypeService
    {
        Task<IEnumerable<TicketType>> GetAllAsync();
        Task<TicketType?> GetByIdAsync(long id);
        Task<IEnumerable<TicketType>> GetByEventIdAsync(long eventId);
        Task<TicketType?> CreateAsync(CreateTicketTypeDto dto);
        Task<TicketType?> UpdateAsync(long id, UpdateTicketTypeDto dto);
        Task<TicketType?> DeleteAsync(long id);
    }
}