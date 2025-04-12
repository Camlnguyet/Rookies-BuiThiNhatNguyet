using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces.Service;

namespace BonApp.Infrastructure.Data.Service;

public class ProductService : IProductService
{
    public Task CreateAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllActiveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> Query()
    {
        throw new NotImplementedException();
    }

    public Task SoftDeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}
