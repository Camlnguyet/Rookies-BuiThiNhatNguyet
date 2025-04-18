using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IOrderRepository
{
    // Lấy entity theo ID
    IQueryable<Order> Orders { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(Order order);
    // Cập nhập entity
    void Update(Order order);
    // Xóa entity
    void Delete(Order order);
    Task SaveChangesAsync();
    Task CreateAsync(Order order);
    Task<IEnumerable<Order>> GetAllAsync();
}
