using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroBannerController(IHeroBannerService heroBannerService) : ControllerBase
    {
        private readonly IHeroBannerService _heroBannerService = heroBannerService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var banners = await _heroBannerService.GetAllAsync();
            return Ok(banners);
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var banner = await _heroBannerService.GetByIdAsync(id);

            if (banner is null)
                return NotFound("Hero banner not found.");

            return Ok(banner);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HeroBanner banner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdBanner = await _heroBannerService.CreateAsync(banner);
            return CreatedAtAction(nameof(GetById), new { id = createdBanner.Id }, createdBanner);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] HeroBanner banner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedBanner = await _heroBannerService.UpdateAsync(id, banner);

            if (updatedBanner is null)
                return NotFound("Hero banner not found.");

            return Ok(updatedBanner);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedBanner = await _heroBannerService.DeleteAsync(id);

            if (deletedBanner is null)
                return NotFound("Hero banner not found.");

            return Ok(deletedBanner);
        }
    }
}