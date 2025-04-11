using System.Linq.Expressions;
using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IProductRepository
{
    // GetAll, GetById, Add, Update, Delete, SaveChange
    // Lấy entity theo ID
    Task<Product?> GetByIdAsync(int id);

    // Lấy tất cả entity
    Task<IEnumerable<Product>> GetAllAsync();

    // Thêm entity mới
    Task AddAsync(Product product);
    // Cập nhập entity
    void Update(Product product);
    // Xóa entity
    void Delete(Product product);

    // Lọc entity theo điều kiện
    // Task<IEnumerable<T>> FindAsync (Expression<Func<T, bool>> predicate);


    // Các phương thức riêng cho Product
    Task<IEnumerable<Product>> GetTopSellingAsync(int count);
    Task<IEnumerable<Product>> SearchByNameAsync(string keyword);

    // Lưu thay đổi (nếu dùng Unit of work, phương thức này có thể không cần)
    // Task SaveChangesAsync();
}
