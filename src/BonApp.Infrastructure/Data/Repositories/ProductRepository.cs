// using BonApp.Domain.Entities;
// using BonApp.Domain.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace BonApp.Infrastructure.Data.Repositories;

// public class ProductRepository : IProductRepository
// {
//     private readonly AppDbContext _context;
//     private readonly DbSet<Product> _products;

//     public ProductRepository(AppDbContext context)
//     {
//         _context = context;
//         _products = context.Set<Product>();
//     }
//     public async Task<Product?> GetByIdAsync(int id)
//     {
//         return _products.GetByIdAsync(id);
//     }
//     public async Task<Product> FindByIdAsync(int id)
//     {
//         return await _products.FindAsync(id);
//     }
//     public async Task<IEnumerable<Product>> GetAllAsync()
//     {
//         return await _products.ToListAsync();
//     }
//     public async Task AddAsync(Product product)
//     {
//         await _products.AddAsync(product);
//     }
//     public void Update(Product product)
//     {
//         _products.Update(product);
//     }
//     public void Delete(Product product)
//     {
//         _products.Remove(product);
//     }
//     public async Task<IEnumerable<Product>> GetProductsAsync(int count)
//     {
//         return await _products.GetAllAsync()
//     }
//     public Task<IEnumerable<Product>> GetTopSellingAsync(int count)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<IEnumerable<Product>> SearchByNameAsync(string keyword)
//     {
//         throw new NotImplementedException();
//     }
// }
