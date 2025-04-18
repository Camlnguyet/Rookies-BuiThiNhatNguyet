using System.Security.Claims;
using BonApp.Application.Interfaces;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReviewController : Controller
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IReviewService _reviewService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ReviewController(IReviewRepository reviewRepository, IReviewService reviewService, IHttpContextAccessor httpContext)
    {
        _reviewRepository = reviewRepository;
        _httpContextAccessor = httpContext;
        _reviewService = reviewService;
    }

    [HttpGet("product/{productId}")]
    public async Task<IActionResult> GetByProduct(int productId)
    {
        var reviews = await _reviewService.GetByProductIdAsync(productId);
        return Ok(reviews);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _reviewService.AddAsync(dto, userId);
        return Ok(new { message = "Review added" });
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var result = await _reviewService.DeleteAsync(id, userId);
        if (!result)
            return Forbid();
        return Ok(new { message = "Review deleted" });
    }
}
