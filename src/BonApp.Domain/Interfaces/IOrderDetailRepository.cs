using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IOrderDetailRepository
{
    // Lấy entity theo ID
    Task<OrderDetail?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<OrderDetail>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(OrderDetail orderDetail);
    // Cập nhập entity
    void Update(OrderDetail orderDetail);
    // Xóa entity
    void Delete(OrderDetail orderDetail);
}
