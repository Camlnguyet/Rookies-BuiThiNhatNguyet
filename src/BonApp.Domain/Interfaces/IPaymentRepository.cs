using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IPaymentRepository
{
    // Lấy entity theo ID
    Task<Payment?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<Payment>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(Payment payment);
    // Cập nhập entity
    void Update(Payment payment);
    // Xóa entity
    void Delete(Payment payment);
}
