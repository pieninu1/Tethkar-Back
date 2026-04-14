using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

public class UserFavoriteService(AppDbContext context) : IUserFavoriteService
{
    private readonly AppDbContext _context = context;

    public async Task<bool> ToggleFavoriteAsync(string userId, long eventId)
    {
        var existing = await _context.UserFavorites
            .FirstOrDefaultAsync(f => f.UserId == userId && f.EventId == eventId);

        if (existing != null)
        {
            _context.UserFavorites.Remove(existing);
            await _context.SaveChangesAsync();
            return false; // removed
        }

        var favorite = new UserFavorite
        {
            UserId = userId,
            EventId = eventId
        };

        await _context.UserFavorites.AddAsync(favorite);
        await _context.SaveChangesAsync();

        return true; // added
    }

    public async Task<IEnumerable<Event>> GetUserFavoritesAsync(string userId)
    {
        return await _context.UserFavorites
            .Where(f => f.UserId == userId)
            .Include(f => f.Event)
                .ThenInclude(e => e!.City)
            .Include(f => f.Event)
                .ThenInclude(e => e!.Category)
            .Select(f => f.Event!)
            .ToListAsync();
    }
}