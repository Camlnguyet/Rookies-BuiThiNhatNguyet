using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Category> Categories => _context.Categories;

    public IQueryable<Product> Products => _context.Products;

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
}
