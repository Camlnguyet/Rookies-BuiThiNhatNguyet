using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Order> Orders => _context.Orders;

    public IQueryable<User> Users => _context.Users;

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }
}
