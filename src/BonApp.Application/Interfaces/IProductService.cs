using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<ProductDetailDto> GetProductByIdAsync(int productId);
    Task<bool> IsProductAvailableAsync(string name);
    Task<Product> CreateProductAsync(CreateProductDto dto);
}
