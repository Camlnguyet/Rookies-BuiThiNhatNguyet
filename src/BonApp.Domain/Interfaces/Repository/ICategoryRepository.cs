using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface ICategoryRepository
{
    // Lấy entity theo ID
    IQueryable<Category> Categories { get; }
    IQueryable<Product> Products{ get; }
    // Thêm entity mới
    void Add(Category category);
    // Cập nhập entity
    void Update(Category category);
    // Xóa entity
    void Delete(Category category);
}
