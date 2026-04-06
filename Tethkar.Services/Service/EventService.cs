using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

public class EventService(AppDbContext context) : IEventService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events
            .Include(e => e.City)
            .Include(e => e.CategoryId)
            .ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(long id)
    {
        return await _context.Events
            .Include(e => e.City)
            .Include(e => e.CategoryId)
            .AsSplitQuery()
            .SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Event?> CreateAsync(Event eventt)
    {
        var cityExists = await _context.Cities.AnyAsync(c => c.Id == eventt.CityId);
        if (!cityExists) return null;

        var organizerExists = await _context.Users.AnyAsync(u => u.Id == eventt.OrganizerId);
        if (!organizerExists) return null;

        await _context.Events.AddAsync(eventt);
        await _context.SaveChangesAsync();
        return eventt;
    }

    public async Task<Event?> UpdateAsync(long id, Event eventt)
    {
        var existingEvent = await _context.Events.FindAsync(id);
        if (existingEvent is null) return null;

        var cityExists = await _context.Cities.AnyAsync(c => c.Id == eventt.CityId);
        if (!cityExists) return null;

        var organizerExists = await _context.Users.AnyAsync(u => u.Id == eventt.OrganizerId);
        if (!organizerExists) return null;

        existingEvent.Name = eventt.Name;
        existingEvent.StartDateTime = eventt.StartDateTime;
        existingEvent.EndDateTime = eventt.EndDateTime;
        existingEvent.CreatedAt = eventt.CreatedAt;
        existingEvent.Venue = eventt.Venue;
        existingEvent.Description = eventt.Description;
        existingEvent.CityId = eventt.CityId;
        existingEvent.OrganizerId = eventt.OrganizerId;

        await _context.SaveChangesAsync();
        return existingEvent;
    }

    public async Task<Event?> DeleteAsync(long id)
    {
        var eventt = await _context.Events.FindAsync(id);
        if (eventt is null) return null;

        _context.Events.Remove(eventt);
        await _context.SaveChangesAsync();
        return eventt;
    }
}