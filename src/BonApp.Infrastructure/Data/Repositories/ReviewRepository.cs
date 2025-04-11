using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;
    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Review> Reviews => _context.Reviews;

    public IQueryable<Product> Products => _context.Products;

    public IQueryable<User> Users => _context.Users;

    public void Add(Review review)
    {
        _context.Reviews.Add(review);
    }

    public void Delete(Review review)
    {
        _context.Reviews.Remove(review);
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
    }
}
