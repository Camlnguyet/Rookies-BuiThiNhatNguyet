using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IUserRepository
{
    // Lấy entity theo 
    Task<User?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<User>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(User user);
    // Cập nhập entity
    void Update(User user);
    // Xóa entity
    void Delete(User user);
}
