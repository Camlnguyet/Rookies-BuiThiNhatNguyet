using AutoMapper;
using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Infrastructure.Data.Mapping;

public class OtherMapper : Profile
{
    public OtherMapper()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<CartDetail, CartItemDto>().ReverseMap();
    }
}
