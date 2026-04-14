using Tethkar.Data.Models;

namespace Tethkar.Services.IService;

public interface IUserFavoriteService
{
    Task<bool> ToggleFavoriteAsync(string userId, long eventId);
    Task<IEnumerable<Event>> GetUserFavoritesAsync(string userId);
}