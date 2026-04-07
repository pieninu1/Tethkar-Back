using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketTypeController(ITicketTypeService ticketTypeService) : ControllerBase
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketType ticketType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTicketType = await _ticketTypeService.CreateAsync(ticketType);

            if (createdTicketType is null)
                return BadRequest("Event does not exist.");

            return CreatedAtAction(nameof(GetById), new { id = createdTicketType.Id }, createdTicketType);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] TicketType ticketType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTicketType = await _ticketTypeService.GetByIdAsync(id);
            if (existingTicketType is null)
                return NotFound("Ticket type not found.");

            var updatedTicketType = await _ticketTypeService.UpdateAsync(id, ticketType);

            if (updatedTicketType is null)
                return BadRequest("Update failed.");

            return Ok(updatedTicketType);
        }

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