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
    public IUnitOfWork UnitOfWork => _context;
    public void Add(Review review)
    {
        _context.Reviews.Add(review);
    }
    public async Task CreateAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public void Delete(Review review)
    {
        _context.Reviews.Remove(review);
    }
    public async Task<IEnumerable<Review>> GetAllAsync()
    {
        return await _context.Reviews.ToListAsync();
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
