namespace BonApp.Infrastructure.Data.DTOs;

public class UpdateProductDto
{
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int DateUse { get; set; }
}
