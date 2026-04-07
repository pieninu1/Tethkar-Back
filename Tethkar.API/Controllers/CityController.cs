using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(ICityService cityService) : ControllerBase
    {
        private readonly ICityService _cityService = cityService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var city = await _cityService.GetByIdAsync(id);

            if (city is null)
                return NotFound("City not found.");

            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCity = await _cityService.CreateAsync(city);

            return CreatedAtAction(nameof(GetById), new { id = createdCity.Id }, createdCity);
        }

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