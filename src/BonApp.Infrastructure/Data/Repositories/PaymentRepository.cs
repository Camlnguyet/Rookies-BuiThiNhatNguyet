using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Infrastructure.Data.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;
    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Payment> Payments => _context.Payments.AsQueryable();
    public IUnitOfWork UnitOfWork => _context;

    public void Add(Payment payment)
    {
        _context.Payments.Add(payment);
    }

    public async Task CreateAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
    }

    public void Delete(Payment payment)
    {
        _context.Payments.Remove(payment);
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }
}
