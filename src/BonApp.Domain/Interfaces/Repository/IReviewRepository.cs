using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IReviewRepository
{
    // Lấy entity theo ID
    IQueryable<Review> Reviews { get; }
    IUnitOfWork unitOfWork { get; }
    void Add(Review review);
    // Cập nhập entity
    void Update(Review review);
    // Xóa entity
    void Delete(Review review);
    Task<IEnumerable<Review>> GetByProductIdAsync(int productId);
    Task<Review> GetByIdAsync(int id);
    Task SaveChangeAsync();
    Task AddAsync(Review review);
    Task DeleteAsync(Review review);
}
