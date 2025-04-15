using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Service;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
        // return await _productService.GetAllProductsAsync();
    }

    public Task<Product> GetProductAsync(int productId)
    {
        throw new NotImplementedException();
    }
}
