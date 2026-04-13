using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.DTOs;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service
{
    public class TicketTypeService(AppDbContext context) : ITicketTypeService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<TicketType>> GetAllAsync()
        {
            return await _context.TicketTypes
                .Include(t => t.Event)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TicketType?> GetByIdAsync(long id)
        {
            return await _context.TicketTypes
                .Include(t => t.Event)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TicketType>> GetByEventIdAsync(long eventId)
        {
            return await _context.TicketTypes
                .Where(t => t.EventId == eventId)
                .Include(t => t.Event)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TicketType?> CreateAsync(CreateTicketTypeDto dto)
        {
            var eventExists = await _context.Events
                .AnyAsync(e => e.Id == dto.EventId);

            if (!eventExists)
                return null;

            var ticketType = new TicketType
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                EventId = dto.EventId
            };

            await _context.TicketTypes.AddAsync(ticketType);
            await _context.SaveChangesAsync();

            return ticketType;
        }

        public async Task<TicketType?> UpdateAsync(long id, UpdateTicketTypeDto dto)
        {
            var existingTicketType = await _context.TicketTypes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTicketType is null)
                return null;

            existingTicketType.Name = dto.Name;
            existingTicketType.Price = dto.Price;
            existingTicketType.Quantity = dto.Quantity;

            await _context.SaveChangesAsync();

            return existingTicketType;
        }

        public async Task<TicketType?> DeleteAsync(long id)
        {
            var ticketType = await _context.TicketTypes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticketType is null)
                return null;

            _context.TicketTypes.Remove(ticketType);
            await _context.SaveChangesAsync();

            return ticketType;
        }
    }
}