using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;
    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Role> Roles => _context.Roles.AsQueryable();

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Role role)
    {
        _context.Roles.Add(role);
    }

    public async Task CreateAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
    }

    public void Delete(Role role)
    {
        _context.Roles.Remove(role);
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
    }
}
