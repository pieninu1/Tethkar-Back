using Tethkar.Data.Models;

namespace Tethkar.Services.IService;

public interface ICityService
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(long id);
    Task<City> CreateAsync(City city);
    Task<City?> UpdateAsync(long id, City city);
    Task<City?> DeleteAsync(long id);
}