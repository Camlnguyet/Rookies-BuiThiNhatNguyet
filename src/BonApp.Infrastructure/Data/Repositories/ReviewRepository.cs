using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;
    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Review> Reviews => _context.Reviews.AsQueryable();
    public IUnitOfWork unitOfWork => _context;

    public void Add(Review review)
    {
        _context.Reviews.Add(review);
    }

    public async Task AddAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public void Delete(Review review)
    {
        _context.Reviews.Remove(review);
    }

    public async Task DeleteAsync(Review review)
    {
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
    }

    public async Task<Review?> GetByIdAsync(int id)
    {
        // tận dụng bộ nhớ context database
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<IEnumerable<Review>> GetByProductIdAsync(int productId)
    {
        // return await _context.Reviews.ToListAsync();
        return await _context.Reviews
            .Include(r => r.User)
            .Where(r => r.ProductId == productId)
            .ToListAsync();
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Review review)
    {
        _context.Reviews.Update(review);
    }
}
