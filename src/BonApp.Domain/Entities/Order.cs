

namespace BonApp.Domain.Entities;

public class Order : BaseEntity
{
    public int Quanity { get; set; }
    public required string Status { get; set; } = default!;
    public required decimal Price_At_Purchase { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    public virtual Payment Payment { get; set; } = default!;
}
