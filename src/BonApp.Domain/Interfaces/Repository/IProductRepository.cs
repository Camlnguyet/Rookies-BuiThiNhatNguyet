using System.Linq.Expressions;
using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IProductRepository
{
    IQueryable<Product> Products { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task SaveChangesAsync();
    Task CreateAsync(Product product);
    Task<IEnumerable<Product>> GetAllAsync();
}
