

namespace BonApp.Domain.Entities;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string Status { get; set; } = default!;
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;
}
