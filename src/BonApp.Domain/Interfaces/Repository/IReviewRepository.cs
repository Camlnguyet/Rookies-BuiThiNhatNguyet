using BonApp.Domain.Entities;

namespace BonApp.Domain.Interfaces;

public interface IReviewRepository
{
    // Lấy entity theo ID
    IQueryable<Review> Reviews { get; }
    IUnitOfWork UnitOfWork { get; }
    void Add(Review review);
    // Cập nhập entity
    void Update(Review review);
    // Xóa entity
    void Delete(Review review);
    Task<IEnumerable<Review>> GetAllAsync();
    Task SaveChangeAsync();
    Task CreateAsync(Review review);
}
