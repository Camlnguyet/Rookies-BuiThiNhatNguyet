

namespace BonApp.Domain.Entities;

public class OrderDetail : BaseEntity
{
    public required int Quantity { get; set; }
    public required decimal Price_At_Purchase { get; set; }
    // order-orderDetail
    public int OrderId { get; set; }
    public virtual required Order Order { get; set; }
    // orderDetail-product
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
}
