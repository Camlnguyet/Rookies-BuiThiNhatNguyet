using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class CartRepository(AppDbContext context) : ICartRepository
{
    private readonly AppDbContext _context = context;

    public IQueryable<Cart> Carts => _context.Carts.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Cart cart)
    {
        _context.Carts.Add(cart);
    }

    public async Task CreateAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
    }

    public void Delete(Cart cart)
    {
        _context.Carts.Remove(cart);
    }

    public async Task<IEnumerable<Cart>> GetAllAsync()
    {
        return await _context.Carts.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Cart cart)
    {
        _context.Carts.Update(cart);
    }
}
