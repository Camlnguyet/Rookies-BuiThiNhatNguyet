using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class AdressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AdressRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<Address> Addresses => _context.Addresses.AsQueryable();
    public IUnitOfWork UnitOfWork => _context;

    public void Add(Address address)
    {
        _context.Addresses.Add(address);
    }
    public void Delete(Address address)
    {
        _context.Addresses.Remove(address);
    }
    public void Update(Address address)
    {
        _context.Addresses.Update(address);
    }
    public async Task CreateAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
    }
    public async Task<IEnumerable<Address>> GetAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
