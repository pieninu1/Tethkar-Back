using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.DTOs;
using Tethkar.Data.Enums;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service
{
    public class TicketService(AppDbContext context) : ITicketService
    {
        private readonly AppDbContext _context = context;

        public async Task<string> BookTicketAsync(BookTicketDto model, string userId)
        {
            var ticketType = await _context.TicketTypes
                .Include(tt => tt.Event)
                .FirstOrDefaultAsync(tt => tt.Id == model.TicketTypeId);

            if (ticketType == null)
                return "نوع التذكرة غير موجود.";

            if (ticketType.Event == null)
                return "الفعالية غير موجودة.";

            if (model.Quantity <= 0)
                return "الكمية يجب أن تكون أكبر من صفر.";

            if (ticketType.Quantity < model.Quantity)
                return "الكمية المطلوبة غير متوفرة.";

            if (model.EventDate.Date < ticketType.Event.StartDateTime.Date ||
                model.EventDate.Date > ticketType.Event.EndDateTime.Date)
                return "التاريخ المختار خارج مدة الفعالية.";

            if (model.EventDate.Date < DateTime.UtcNow.Date)
                return "لا يمكن حجز تذكرة لتاريخ منتهي.";

            var tickets = new List<Ticket>();

            for (int i = 0; i < model.Quantity; i++)
            {
                tickets.Add(new Ticket
                {
                    PurchasedAt = DateTime.UtcNow,
                    EventDate = model.EventDate.Date,
                    Status = TicketStatusEnum.Active,
                    TicketTypeId = ticketType.Id,
                    BuyerUserId = userId
                });
            }

            await _context.Tickets.AddRangeAsync(tickets);

            ticketType.Quantity -= model.Quantity;

            await _context.SaveChangesAsync();

            return string.Empty;
        }

        public async Task<IEnumerable<MyTicketDto>> GetMyTicketsAsync(string userId)
        {
            var today = DateTime.UtcNow.Date;

            return await _context.Tickets
                .Include(t => t.TicketType)
                    .ThenInclude(tt => tt!.Event)
                        .ThenInclude(e => e!.City)
                .Where(t => t.BuyerUserId == userId)
                .OrderByDescending(t => t.PurchasedAt)
                .Select(t => new MyTicketDto
                {
                    TicketId = t.Id,
                    EventId = t.TicketType != null && t.TicketType.Event != null
                        ? t.TicketType.Event.Id
                        : 0,
                    EventName = t.TicketType != null && t.TicketType.Event != null
                        ? t.TicketType.Event.Name
                        : string.Empty,
                    TicketTypeName = t.TicketType != null
                        ? t.TicketType.Name
                        : string.Empty,
                    EventDate = t.EventDate,
                    CityName = t.TicketType != null &&
                               t.TicketType.Event != null &&
                               t.TicketType.Event.City != null
                        ? t.TicketType.Event.City.Name
                        : string.Empty,
                    CardImageUrl = t.TicketType != null && t.TicketType.Event != null
                        ? t.TicketType.Event.CardImageUrl
                        : string.Empty,
                    Status = t.EventDate.Date < today ? "Expired" : "Active"
                })
                .ToListAsync();
        }
    }
}