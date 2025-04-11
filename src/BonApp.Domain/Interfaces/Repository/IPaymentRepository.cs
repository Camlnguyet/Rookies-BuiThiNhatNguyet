using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IPaymentRepository
{
    IQueryable<Payment> Payments { get; }
    IQueryable<Order> Orders { get; }
    // Lấy entity theo ID
    void Add(Payment payment);
    // Cập nhập entity
    void Update(Payment payment);
    // Xóa entity
    void Delete(Payment payment);
}
