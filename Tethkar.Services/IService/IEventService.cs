using Tethkar.Data.Models;

namespace Tethkar.Services.IService;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(long id);
    Task<Event?> CreateAsync(Event eventt);
    Task<Event?> UpdateAsync(long id, Event eventt);
    Task<Event?> DeleteAsync(long id);
}