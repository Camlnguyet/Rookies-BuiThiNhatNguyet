// using BonApp.Domain.Entities;
// using BonApp.Domain.Interfaces;
// using Microsoft.EntityFrameworkCore;

// namespace BonApp.Infrastructure.Data.Repositories;

// public class GenericRepository<T> : IGenericRepository<T> 
// {
//     protected readonly AppDbContext _context;
//     protected readonly DbSet<T> _dbSet;

//     public GenericRepository(AppDbContext context)
//     {
//         _context = context;
//         _dbSet = context.Set<T>();
//     }

//     public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
//     public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
//     public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
//     public void Update(T entity) => _dbSet.Update(entity);
//     public void Delete(T entity) => _dbSet.Remove(entity);

//     public Task<T?> GetAsync(int id)
//     {
//         throw new NotImplementedException();
//     }

//     public void Delete(int id)
//     {
//         throw new NotImplementedException();
//     }
// }
