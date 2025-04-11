namespace BonApp.Domain.Entities;

public class Cart : BaseEntity
{
    // cart-user
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;

    // cart-cart.detail
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
}
