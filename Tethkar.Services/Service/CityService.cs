using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

public class CityService(AppDbContext context) : ICityService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.AsNoTracking().ToListAsync();
    }

    public async Task<City?> GetByIdAsync(long id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<City> CreateAsync(City city)
    {
        await _context.Cities.AddAsync(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task<City?> UpdateAsync(long id, City city)
    {
        var existingCity = await _context.Cities.FindAsync(id);
        if (existingCity is null) return null;

        existingCity.Name = city.Name;

        await _context.SaveChangesAsync();
        return existingCity;
    }

    public async Task<City?> DeleteAsync(long id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city is null) return null;

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
        return city;
    }
}