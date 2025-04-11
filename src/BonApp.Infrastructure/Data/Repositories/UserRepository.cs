using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<User> Users => _context.Users;

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }
}
