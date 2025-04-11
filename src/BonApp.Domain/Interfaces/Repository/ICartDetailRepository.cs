using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICartDetailRepository
{
    IQueryable<CartDetail> CartDetails { get; }
    IQueryable<Cart> Carts { get; }
    IQueryable<Product> Products { get; }
    // Thêm entity mới
    void Add(CartDetail cartDetail);
    // Cập nhập entity
    void Update(CartDetail cartDetail);
    // Xóa entity
    void Delete(CartDetail cartDetail);

}
