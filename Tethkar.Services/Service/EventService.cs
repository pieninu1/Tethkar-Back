using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.DTOs.Event;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

public class EventService(AppDbContext context) : IEventService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<EventReadDto>> GetAllAsync()
    {
        return await _context.Events
            .Include(e => e.City)
            .Include(e => e.Category)
            .Include(e => e.TicketTypes)
            .AsNoTracking()
            .Select(e => new EventReadDto
            {
                Id = e.Id,
                Name = e.Name,
                StartDateTime = e.StartDateTime,
                EndDateTime = e.EndDateTime,
                CreatedAt = e.CreatedAt,
                Venue = e.Venue,
                Description = e.Description,
                TermsAndConditions = e.TermsAndConditions,
                CardImageUrl = e.CardImageUrl,
                DetailsImageUrl1 = e.DetailsImageUrl1,
                DetailsImageUrl2 = e.DetailsImageUrl2,
                CityId = e.CityId,
                CityName = e.City != null ? e.City.Name : string.Empty,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.Name : string.Empty,
                LowestTicketPrice = e.TicketTypes.Any()
                    ? e.TicketTypes.Min(t => t.Price)
                    : null
            })
            .ToListAsync();
    }

    public async Task<EventReadDto?> GetByIdAsync(long id)
    {
        return await _context.Events
            .Include(e => e.City)
            .Include(e => e.Category)
            .Include(e => e.Organizer)
            .Include(e => e.TicketTypes)
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Select(e => new EventReadDto
            {
                Id = e.Id,
                Name = e.Name,
                StartDateTime = e.StartDateTime,
                EndDateTime = e.EndDateTime,
                CreatedAt = e.CreatedAt,
                Venue = e.Venue,
                Description = e.Description,
                TermsAndConditions = e.TermsAndConditions,
                CardImageUrl = e.CardImageUrl,
                DetailsImageUrl1 = e.DetailsImageUrl1,
                DetailsImageUrl2 = e.DetailsImageUrl2,
                CityId = e.CityId,
                CityName = e.City != null ? e.City.Name : string.Empty,
                CategoryId = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.Name : string.Empty,
                LowestTicketPrice = e.TicketTypes.Any()
                    ? e.TicketTypes.Min(t => t.Price)
                    : null
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Event?> CreateAsync(Event eventt)
    {
        var cityExists = await _context.Cities.AnyAsync(c => c.Id == eventt.CityId);
        if (!cityExists) return null;

        var organizerExists = await _context.Users.AnyAsync(u => u.Id == eventt.OrganizerId);
        if (!organizerExists) return null;

        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == eventt.CategoryId);
        if (!categoryExists) return null;

        if (eventt.CreatedAt == default)
            eventt.CreatedAt = DateTime.UtcNow;

        await _context.Events.AddAsync(eventt);
        await _context.SaveChangesAsync();

        return eventt;
    }

    public async Task<Event?> UpdateAsync(long id, Event eventt)
    {
        var existingEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (existingEvent is null) return null;

        var cityExists = await _context.Cities.AnyAsync(c => c.Id == eventt.CityId);
        if (!cityExists) return null;

        var organizerExists = await _context.Users.AnyAsync(u => u.Id == eventt.OrganizerId);
        if (!organizerExists) return null;

        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == eventt.CategoryId);
        if (!categoryExists) return null;

        existingEvent.Name = eventt.Name;
        existingEvent.StartDateTime = eventt.StartDateTime;
        existingEvent.EndDateTime = eventt.EndDateTime;
        existingEvent.Venue = eventt.Venue;
        existingEvent.Description = eventt.Description;
        existingEvent.TermsAndConditions = eventt.TermsAndConditions;
        existingEvent.CardImageUrl = eventt.CardImageUrl;
        existingEvent.DetailsImageUrl1 = eventt.DetailsImageUrl1;
        existingEvent.DetailsImageUrl2 = eventt.DetailsImageUrl2;
        existingEvent.CityId = eventt.CityId;
        existingEvent.OrganizerId = eventt.OrganizerId;
        existingEvent.CategoryId = eventt.CategoryId;

        await _context.SaveChangesAsync();

        return existingEvent;
    }

    public async Task<Event?> DeleteAsync(long id)
    {
        var eventt = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (eventt is null) return null;

        _context.Events.Remove(eventt);
        await _context.SaveChangesAsync();

        return eventt;
    }
}