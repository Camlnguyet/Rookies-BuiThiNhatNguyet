namespace BonApp.Infrastructure.Data.DTOs;

public class CreateProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; } = string.Empty;
    public decimal Price { get; set; }
    public DateTimeOffset DateProduce { get; set; }
    public int DateUse { get; set; }
    public string CategoryName { get; set; } = default!;

}
