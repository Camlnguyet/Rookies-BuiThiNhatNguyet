using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IReviewRepository
{
    // Lấy entity theo ID
    Task<Review?> GetByIdAsync(int id);
    // Lấy tất cả entity
    Task<IEnumerable<Review>> GetAllAsync();
    // Thêm entity mới
    Task AddAsync(Review newReview);
    // Cập nhập entity
    void Update(Review newReview);
    // Xóa entity
    void Delete(Review review);
}
