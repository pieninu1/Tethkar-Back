using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserFavoriteController(IUserFavoriteService service) : ControllerBase
    {
        private readonly IUserFavoriteService _service = service;

        [HttpPost("{eventId}")]
        public async Task<IActionResult> Toggle(long eventId)
        {
            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var result = await _service.ToggleFavoriteAsync(userId, eventId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFavorites()
        {
            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var events = await _service.GetUserFavoritesAsync(userId);

            return Ok(events);
        }
    }
}