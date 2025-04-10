// using BonApp.Domain.Entities;
// using BonApp.Domain.Interfaces;

// namespace BonApp.Infrastructure.Data.Repositories;

// public class UnitOfWork : IUnitOfWork
// {
//     private readonly AppDbContext _context;
//     private IGenericRepository<Product>? _productRepo;
//     public UnitOfWork(AppDbContext context)
//     {
//         _context = context;
//     }

//     public IGenericRepository<Product> Products =>
//     _productRepo ??= new GenericRepository<Product>(_context);
//     public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
//     public void Dispose() => _context.Dispose();
// }
