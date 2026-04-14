using Tethkar.Data.Models;

namespace Tethkar.Services.IService
{
    public interface IHeroBannerService
    {
        Task<IEnumerable<HeroBanner>> GetAllAsync();
        Task<HeroBanner?> GetByIdAsync(long id);
        Task<HeroBanner> CreateAsync(HeroBanner banner);
        Task<HeroBanner?> UpdateAsync(long id, HeroBanner banner);
        Task<HeroBanner?> DeleteAsync(long id);
    }
}