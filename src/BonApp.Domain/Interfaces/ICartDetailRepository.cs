using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICartDetailRepository
{
    // Lấy entity theo ID
    Task<CartDetail?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<CartDetail>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(CartDetail cartDetail);
    // Cập nhập entity
    void Update(CartDetail cartDetail);
    // Xóa entity
    void Delete(CartDetail cartDetail);

}
