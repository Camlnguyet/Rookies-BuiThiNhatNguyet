using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IPaymentRepository
{
    IQueryable<Payment> Payments { get; }
    IUnitOfWork UnitOfWork { get; }
    // Lấy entity theo ID
    void Add(Payment payment);
    // Cập nhập entity
    void Update(Payment payment);
    // Xóa entity
    void Delete(Payment payment);
    Task SaveChangesAsync();
    Task CreateAsync(Payment payment);
    Task<IEnumerable<Payment>> GetAllAsync();
}
