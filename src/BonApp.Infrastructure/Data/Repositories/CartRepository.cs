using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class CartRepository(AppDbContext context) : ICartRepository
{
    private readonly AppDbContext _context = context;

    public IQueryable<Cart> Carts => _context.Carts;
    public IQueryable<User> Users => _context.Users;

    public void Add(Cart cart)
    {
        _context.Carts.Add(cart);
    }

    public void Delete(Cart cart)
    {
        _context.Carts.Remove(cart);
    }
    public void Update(Cart cart)
    {
        _context.Carts.Update(cart);
    }
}
