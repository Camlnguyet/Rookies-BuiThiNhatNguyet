using AutoMapper;
using BonApp.Application.Interfaces;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepo;
    private readonly IMapper _mapper;

    public ReviewService(IReviewRepository reviewRepo, IMapper mapper)
    {
        _reviewRepo = reviewRepo;
        _mapper = mapper;
    }
    public async Task AddAsync(CreateReviewDto dto, int userId)
    {
        var review = new Review
        {
            ProductId = dto.ProductId,
            UserId = userId,
            Comment = dto.Content,
            Rating = dto.Rating,
            CreatedAt = DateTime.UtcNow
        };
        await _reviewRepo.AddAsync(review);
        await _reviewRepo.SaveChangeAsync();
    }

    public async Task<bool> DeleteAsync(int reviewId, int userId)
    {
        var review = await _reviewRepo.GetByIdAsync(reviewId);
        if (review == null || review.UserId != userId)
            return false;

        await _reviewRepo.DeleteAsync(review);
        return true;
    }

    public async Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId)
    {
        var reviews = await _reviewRepo.GetByProductIdAsync(productId);
        return reviews.Select(r => new ReviewDto
        {
            Comment = r.Comment,
            Rating = r.Rating,
            UserName = r.User?.UserName,
        });
    }
}
