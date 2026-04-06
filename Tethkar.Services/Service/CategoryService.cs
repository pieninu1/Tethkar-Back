using Microsoft.EntityFrameworkCore;
using Tethkar.Data.Data;
using Tethkar.Data.Models;
using Tethkar.Services.IService;

namespace Tethkar.Services.Service;

public class CategoryService(AppDbContext context) : ICategoryService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(long id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> UpdateAsync(long id, Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory is null) return null;

        existingCategory.Name = category.Name;

        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<Category?> DeleteAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null) return null;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }
}