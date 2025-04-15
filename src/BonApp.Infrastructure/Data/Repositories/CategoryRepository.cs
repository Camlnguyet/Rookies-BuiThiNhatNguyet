using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Category> Categories => _context.Categories.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Category category)
    {
        _context.Categories.Add(category);
    }

    public void Delete(Category category)
    {
        _context.Categories.Remove(category);
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }
    public async Task CreateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
    }
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
