using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class CartDetailRepository : ICartDetailRepository
{
    private readonly AppDbContext _context;
    public CartDetailRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<CartDetail> CartsDetail => _context.CartsDetail.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(CartDetail cartDetail)
    {
        _context.CartsDetail.Add(cartDetail);
    }

    public async Task CreateAsync(CartDetail cartDetail)
    {
        await _context.CartsDetail.AddAsync(cartDetail);
    }

    public void Delete(CartDetail cartDetail)
    {
        _context.CartsDetail.Remove(cartDetail);
    }

    public async Task<IEnumerable<CartDetail>> GetAllAsync()
    {
        return await _context.CartsDetail.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(CartDetail cartDetail)
    {
        _context.CartsDetail.Update(cartDetail);
    }
}
