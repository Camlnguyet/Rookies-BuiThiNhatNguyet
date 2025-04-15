using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Service;
using AutoMapper;
using BonApp.Infrastructure.Data.DTOs;
using BonApp.Domain.Entities;

namespace BonApp.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartService _cartService;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, ICartService cartService, IProductRepository productRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _cartService = cartService;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    // --- Define OrderStatus Enum ---
    // Domain/Enums/OrderStatus.cs
    public enum OrderStatus
    {
        PendingPayment,
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        Failed
    }
}
