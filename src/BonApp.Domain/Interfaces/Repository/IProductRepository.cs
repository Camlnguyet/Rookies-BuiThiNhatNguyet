using System.Linq.Expressions;
using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IProductRepository
{
    // GetAll, GetById, Add, Update, Delete, SaveChange

    // Lọc entity theo điều kiện
    // Task<IEnumerable<T>> FindAsync (Expression<Func<T, bool>> predicate);
    // join bảng, viết query điều kiện 
    IQueryable<Product> Products { get; }
    IQueryable<Category> Categories { get; }
    void Add(Product product);
    void Update(Product product);
    void Delete(Product product);

    // Các phương thức riêng cho Product-> chuyển sang service

    // Lưu thay đổi (nếu dùng Unit of work, phương thức này có thể không cần)
    // Task SaveChangesAsync();
}
