namespace BonApp.Infrastructure.Data.DTOs;

public class CreateReviewDto
{
    public int ProductId { get; set; }
    public int Rating { get; set; }
    public string Content { get; set; } = default!;
}
