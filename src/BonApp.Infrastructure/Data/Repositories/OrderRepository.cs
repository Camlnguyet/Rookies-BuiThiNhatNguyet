using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Order> Orders => _context.Orders.AsQueryable();
    public IUnitOfWork UnitOfWork => _context;

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public async Task CreateAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }
}
