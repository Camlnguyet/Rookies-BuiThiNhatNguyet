using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IReviewRepository
{
    // Lấy entity theo ID
    IQueryable<Review> Reviews { get; }
    IQueryable<Product> Products { get; }
    IQueryable<User> Users { get; }
    void Add(Review review);
    // Cập nhập entity
    void Update(Review review);
    // Xóa entity
    void Delete(Review review);
}
