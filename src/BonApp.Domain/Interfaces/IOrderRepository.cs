using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IOrderRepository
{
    // Lấy entity theo ID
    Task<Order> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<Order>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(Order order);
    // Cập nhập entity
    void Update(Order order);
    // Xóa entity
    void Delete(Order order);
}
