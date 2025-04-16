using AutoMapper;
using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Infrastructure.Data.Mapping;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, ProductDetailDto>().ReverseMap();
        CreateMap<Product, ProductListDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    
    }
}
