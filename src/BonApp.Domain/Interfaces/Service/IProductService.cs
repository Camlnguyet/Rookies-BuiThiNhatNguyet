using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces.Service;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductAsync(int productId);
}
