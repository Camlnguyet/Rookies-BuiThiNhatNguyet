using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Interfaces;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId);
    Task AddAsync(CreateReviewDto dto, int userId);
    Task<bool> DeleteAsync(int reviewId, int userId);
}
