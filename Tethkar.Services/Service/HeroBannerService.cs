using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service
{
    public class HeroBannerService(AppDbContext context) : IHeroBannerService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<HeroBanner>> GetAllAsync()
        {
            return await _context.HeroBanners
                .Where(b => b.IsActive)
                .OrderBy(b => b.DisplayOrder)
                .ThenBy(b => b.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<HeroBanner?> GetByIdAsync(long id)
        {
            return await _context.HeroBanners
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<HeroBanner> CreateAsync(HeroBanner banner)
        {
            await _context.HeroBanners.AddAsync(banner);
            await _context.SaveChangesAsync();
            return banner;
        }

        public async Task<HeroBanner?> UpdateAsync(long id, HeroBanner banner)
        {
            var existingBanner = await _context.HeroBanners
                .FirstOrDefaultAsync(b => b.Id == id);

            if (existingBanner is null) return null;

            existingBanner.Title = banner.Title;
            existingBanner.Subtitle = banner.Subtitle;
            existingBanner.ImageUrl = banner.ImageUrl;
            existingBanner.ButtonText = banner.ButtonText;
            existingBanner.ButtonLink = banner.ButtonLink;
            existingBanner.DisplayOrder = banner.DisplayOrder;
            existingBanner.IsActive = banner.IsActive;

            await _context.SaveChangesAsync();
            return existingBanner;
        }

        public async Task<HeroBanner?> DeleteAsync(long id)
        {
            var banner = await _context.HeroBanners
                .FirstOrDefaultAsync(b => b.Id == id);

            if (banner is null) return null;

            _context.HeroBanners.Remove(banner);
            await _context.SaveChangesAsync();

            return banner;
        }
    }
}