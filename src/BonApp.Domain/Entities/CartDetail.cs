

namespace BonApp.Domain.Entities;

public class CartDetail : BaseEntity
{
    public int Quantity { get; set; }
    // cart-cart.detail
    public int CartId { get; set; }
    public virtual required Cart Cart { get; set; }

    // cart-detail - product
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
}
