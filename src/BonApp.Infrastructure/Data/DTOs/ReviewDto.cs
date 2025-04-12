namespace BonApp.Infrastructure.Data.DTOs;
// Xem đánh giá
public class ReviewDto
{
    public int Id { get; }
    public string UserName { get; set; } = default!;
    public int Rating { get; set; }
    public string Comment { get; set; } = "";
    public string ProductName { get; set; } = default!;
}
