using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public IUnitOfWork UnitOfWork => _context;
    public IQueryable<User> Users => _context.Users.AsQueryable();

    public void Add(User user)
    {
        _context.Users.Add(user);
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }
    public void Update(User user)
    {
        _context.Users.Update(user);
    }
    public async Task CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
}
