using Tethkar.Data.DTOs.Event;
using Tethkar.Data.Models;

namespace Tethkar.Services.IService;

public interface IEventService
{
    Task<IEnumerable<EventReadDto>> GetAllAsync();
    Task<EventReadDto?> GetByIdAsync(long id);
    Task<Event?> CreateAsync(Event eventt);
    Task<Event?> UpdateAsync(long id, Event eventt);
    Task<Event?> DeleteAsync(long id);
}