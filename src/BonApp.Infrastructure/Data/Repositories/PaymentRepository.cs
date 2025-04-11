using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;

namespace BonApp.Infrastructure.Data.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;
    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }
    public IQueryable<Payment> Payments => _context.Payments;

    public IQueryable<Order> Orders => _context.Orders;
    public void Add(Payment payment)
    {
        _context.Payments.Add(payment);
    }

    public void Delete(Payment payment)
    {
        _context.Payments.Remove(payment);
    }

    public void Update(Payment payment)
    {
        _context.Payments.Update(payment);
    }
}
