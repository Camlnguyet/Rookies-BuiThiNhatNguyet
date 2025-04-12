namespace BonApp.Infrastructure.Data.DTOs;

public class CartItemDto
{
    public int Id { get; set; }
    public string ProductName { get; set; } = default!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
