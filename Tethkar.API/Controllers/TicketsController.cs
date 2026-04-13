using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tethkar.Data.DTOs;
using Tethkar.Services.IService;

namespace Tethkar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicketService ticketService) : ControllerBase
    {
        private readonly ITicketService _ticketService = ticketService;

        [Authorize]
        [HttpPost("book")]
        public async Task<IActionResult> BookTicket([FromBody] BookTicketDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User not found.");

            var result = await _ticketService.BookTicketAsync(model, userId);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok("تم حجز التذكرة بنجاح.");
        }

        [Authorize]
        [HttpGet("my")]
        public async Task<IActionResult> GetMyTickets()
        {
            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User not found.");

            var tickets = await _ticketService.GetMyTicketsAsync(userId);

            return Ok(tickets);
        }
    }
}