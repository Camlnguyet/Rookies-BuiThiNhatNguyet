

namespace BonApp.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public required string PaymentMethod { get; set; }
    public required string Status { get; set; }
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
