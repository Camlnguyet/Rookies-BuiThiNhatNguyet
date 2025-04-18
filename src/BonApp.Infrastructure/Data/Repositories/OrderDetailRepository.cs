using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly AppDbContext _context;
    public OrderDetailRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<OrderDetail> OrderDetails => _context.OrderDetails.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(OrderDetail orderDetail)
    {
        _context.OrderDetails.Add(orderDetail);
    }

    public async Task CreateAsync(OrderDetail orderDetail)
    {
        await _context.OrderDetails.AddAsync(orderDetail);
    }

    public void Delete(OrderDetail orderDetail)
    {
        _context.OrderDetails.Remove(orderDetail);
    }

    public async Task<IEnumerable<OrderDetail>> GetAllAsync()
    {
        return await _context.OrderDetails.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(OrderDetail orderDetail)
    {
        _context.OrderDetails.Update(orderDetail);
    }
}
