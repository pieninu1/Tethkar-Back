using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CityController(ICityService cityService) : ControllerBase
    {
        private readonly ICityService _cityService = cityService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(cities);
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var city = await _cityService.GetByIdAsync(id);

            if (city is null)
                return NotFound("City not found.");

            return Ok(city);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCity = await _cityService.CreateAsync(city);

            return CreatedAtAction(nameof(GetById), new { id = createdCity.Id }, createdCity);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedCity = await _cityService.UpdateAsync(id, city);

            if (updatedCity is null)
                return NotFound("City not found.");

            return Ok(updatedCity);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedCity = await _cityService.DeleteAsync(id);

            if (deletedCity is null)
                return NotFound("City not found.");

            return Ok(deletedCity);
        }
    }
}