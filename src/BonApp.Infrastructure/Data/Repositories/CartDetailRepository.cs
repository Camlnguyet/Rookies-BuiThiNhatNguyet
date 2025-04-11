using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class CartDetailRepository : ICartDetailRepository
{
    private readonly AppDbContext _context;
    public CartDetailRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<CartDetail> CartDetails => _context.CartsDetail;
    public IQueryable<Cart> Carts => _context.Carts;
    public IQueryable<Product> Products => _context.Products;

    public void Add(CartDetail cartDetail)
    {
        _context.CartsDetail.Add(cartDetail);
    }

    public void Delete(CartDetail cartDetail)
    {
        _context.CartsDetail.Remove(cartDetail);
    }
    public void Update(CartDetail cartDetail)
    {
        _context.CartsDetail.Update(cartDetail);
    }
}
