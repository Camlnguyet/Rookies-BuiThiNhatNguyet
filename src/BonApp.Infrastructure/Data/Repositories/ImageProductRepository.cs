using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class ImageProductRepository : IImageProductRepository
{
    private readonly AppDbContext _context;
    public ImageProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<ImageProduct> ImageProducts => _context.ImageProducts.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(ImageProduct imageProduct)
    {
        _context.ImageProducts.Add(imageProduct);
    }

    public async Task CreateAsync(ImageProduct imageProduct)
    {
        await _context.ImageProducts.AddAsync(imageProduct);
    }

    public void Delete(ImageProduct imageProduct)
    {
        _context.ImageProducts.Remove(imageProduct);
    }

    public async Task<IEnumerable<ImageProduct>> GetAllAsync()
    {
        return await _context.ImageProducts.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(ImageProduct imageProduct)
    {
        _context.ImageProducts.Update(imageProduct);
    }
}
