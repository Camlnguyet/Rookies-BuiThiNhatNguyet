using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICategoryRepository
{
    // Lấy entity theo ID
    Task<Category?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<Category>> GetAllAsync();
    // Thêm entity mới
    Task AddAsunc(Category category);
    // Cập nhập entity
    void Update(Category category);
    // Xóa entity
    void Delete(Category category);
}
