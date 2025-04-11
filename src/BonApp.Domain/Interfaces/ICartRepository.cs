using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICartRepository
{
    // lấy entity theo ID
    Task<Cart?> GetByIdAsync(int id);
    // Lấy tất cả entities
    Task<IEnumerable<Cart>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(Cart cart);
    // Cập nhập entity
    void Update(Cart cart);
    // Xóa entity
    void Delete(Cart cart);
}
