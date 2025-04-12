namespace BonApp.Infrastructure.Data.DTOs;

// Xem mô tả, đánh giá
public class ProductDetailDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = default!;
    public DateTimeOffset DateProduce { get; set; }
}
