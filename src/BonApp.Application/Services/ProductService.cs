using AutoMapper;
using BonApp.Application.Interfaces;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

using BonApp.Infrastructure.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Application.Services;

public class ProductService : IProductService
{
    // private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.Products.ToListAsync();
    }
    public async Task<ProductDetailDto?> GetProductByIdAsync(int productId)
    {
        // chưa check nè
        // throw new NotImplementedException();
        var product = await _productRepository.Products.FirstOrDefaultAsync(x => x.Id == productId);
        return product == null ? null : _mapper.Map<ProductDetailDto>(product);
    }
    public async Task<bool> IsProductAvailableAsync(string name)
    {
        return await _productRepository.Products.AnyAsync(p => p.ProductName.ToLower().Trim() == name.ToLower().Trim());
    }
    public async Task<Product> CreateProductAsync(CreateProductDto dto)
    {
        if (await IsProductAvailableAsync(dto.ProductName))
        {
            return null;
        }
        var Product = new Product
        {
            ProductName = dto.ProductName,
        };
        await _productRepository.CreateAsync(Product);
        await _productRepository.UnitOfWork.SaveChangesAsync();

        return Product;
    }

    public Task<Product> GetProductAsync(int productId)
    {
        throw new NotImplementedException();
    }
}