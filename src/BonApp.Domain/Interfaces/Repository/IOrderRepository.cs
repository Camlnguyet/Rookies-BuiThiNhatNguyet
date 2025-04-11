using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IOrderRepository
{
    // Lấy entity theo ID
    IQueryable<Order> Orders { get; }
    IQueryable<User> Users { get; }
    void Add(Order order);
    // Cập nhập entity
    void Update(Order order);
    // Xóa entity
    void Delete(Order order);
}
