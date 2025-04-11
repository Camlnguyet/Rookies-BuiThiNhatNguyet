using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly AppDbContext _context;
    public OrderDetailRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<OrderDetail> OrderDetails => _context.OrderDetails;

    public IQueryable<Product> Products => _context.Products;

    public void Add(OrderDetail orderDetail)
    {
        _context.OrderDetails.Add(orderDetail);
    }

    public void Delete(OrderDetail orderDetail)
    {
        _context.OrderDetails.Remove(orderDetail);
    }

    public void Update(OrderDetail orderDetail)
    {
        _context.OrderDetails.Update(orderDetail);
    }
}
