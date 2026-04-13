using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController(IEventService eventService) : ControllerBase
    {
        private readonly IEventService _eventService = eventService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }

        [AllowAnonymous]
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var eventt = await _eventService.GetByIdAsync(id);

            if (eventt is null)
                return NotFound("Event not found.");

            return Ok(eventt);
        }

        [Authorize(Roles = "Organizer,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event eventt)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var organizerId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(organizerId))
                return Unauthorized("Organizer id not found in token.");

            eventt.OrganizerId = organizerId;

            var createdEvent = await _eventService.CreateAsync(eventt);

            if (createdEvent is null)
                return BadRequest("City, organizer, or category does not exist.");

            return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
        }

        [Authorize(Roles = "Organizer,Admin")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] Event eventt)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEvent = await _eventService.GetByIdAsync(id);

            if (existingEvent is null)
                return NotFound("Event not found.");

            var organizerId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(organizerId))
                return Unauthorized("Organizer id not found in token.");

            eventt.OrganizerId = organizerId;

            var updatedEvent = await _eventService.UpdateAsync(id, eventt);

            if (updatedEvent is null)
                return BadRequest("City, organizer, or category does not exist.");

            return Ok(updatedEvent);
        }

        [Authorize(Roles = "Organizer,Admin")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedEvent = await _eventService.DeleteAsync(id);

            if (deletedEvent is null)
                return NotFound("Event not found.");

            return Ok(deletedEvent);
        }
    }
}