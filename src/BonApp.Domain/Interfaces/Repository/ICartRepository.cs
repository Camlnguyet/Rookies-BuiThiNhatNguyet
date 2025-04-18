using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICartRepository
{
    IQueryable<Cart> Carts { get; }
    IUnitOfWork UnitOfWork { get; }
    // Thêm entity mới
    void Add(Cart cart);
    // Cập nhập entity
    void Update(Cart cart);
    // Xóa entity
    void Delete(Cart cart);
    Task SaveChangesAsync();
    Task CreateAsync(Cart cart);
    Task<IEnumerable<Cart>> GetAllAsync();
}
