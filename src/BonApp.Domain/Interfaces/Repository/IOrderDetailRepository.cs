using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IOrderDetailRepository
{
    // Lấy entity theo ID
    IQueryable<OrderDetail> OrderDetails { get; }
    IQueryable<Product> Products { get; }
    // Thêm entity mới
    void Add(OrderDetail orderDetail);
    // Cập nhập entity
    void Update(OrderDetail orderDetail);
    // Xóa entity
    void Delete(OrderDetail orderDetail);
}
