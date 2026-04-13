using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.DTOs;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketTypesController(ITicketTypeService ticketTypeService) : ControllerBase
    {
        private readonly ITicketTypeService _ticketTypeService = ticketTypeService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ticketTypes = await _ticketTypeService.GetAllAsync();
            return Ok(ticketTypes);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var ticketType = await _ticketTypeService.GetByIdAsync(id);

            if (ticketType is null)
                return NotFound("Ticket type not found.");

            return Ok(ticketType);
        }

        [HttpGet("event/{eventId:long}")]
        public async Task<IActionResult> GetByEventId(long eventId)
        {
            var ticketTypes = await _ticketTypeService.GetByEventIdAsync(eventId);
            return Ok(ticketTypes);
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketTypeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTicketType = await _ticketTypeService.CreateAsync(dto);

            if (createdTicketType is null)
                return BadRequest("Event does not exist.");

            return CreatedAtAction(nameof(GetById), new { id = createdTicketType.Id }, createdTicketType);
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateTicketTypeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTicketType = await _ticketTypeService.GetByIdAsync(id);

            if (existingTicketType is null)
                return NotFound("Ticket type not found.");

            var updatedTicketType = await _ticketTypeService.UpdateAsync(id, dto);

            if (updatedTicketType is null)
                return BadRequest("Update failed.");

            return Ok(updatedTicketType);
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedTicketType = await _ticketTypeService.DeleteAsync(id);

            if (deletedTicketType is null)
                return NotFound("Ticket type not found.");

            return Ok(deletedTicketType);
        }
    }
}