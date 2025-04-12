namespace BonApp.Infrastructure.Data.DTOs;

public class PaymentDto
{
    public int Id { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string Status { get; set; } = default!;
    public decimal? Amount { get; set; }
    public int OrderId { get; set; }
}
