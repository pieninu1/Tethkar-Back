using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

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

    public async Task<TicketType?> CreateAsync(TicketType ticketType)
    {
        var eventExists = await _context.Events
            .AnyAsync(e => e.Id == ticketType.EventId);

        if (!eventExists) return null;

        await _context.TicketTypes.AddAsync(ticketType);
        await _context.SaveChangesAsync();

        return ticketType;
    }

    public async Task<TicketType?> UpdateAsync(long id, TicketType ticketType)
    {
        var existingTicketType = await _context.TicketTypes
            .FirstOrDefaultAsync(t => t.Id == id);

        if (existingTicketType is null) return null;

        existingTicketType.Name = ticketType.Name;
        existingTicketType.Price = ticketType.Price;
        existingTicketType.Quantity = ticketType.Quantity;

        await _context.SaveChangesAsync();

        return existingTicketType;
    }

    public async Task<TicketType?> DeleteAsync(long id)
    {
        var ticketType = await _context.TicketTypes
            .FirstOrDefaultAsync(t => t.Id == id);

        if (ticketType is null) return null;

        _context.TicketTypes.Remove(ticketType);
        await _context.SaveChangesAsync();

        return ticketType;
    }
}