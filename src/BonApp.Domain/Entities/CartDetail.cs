

namespace BonApp.Domain.Entities;

public class CartDetail : BaseEntity
{
    public int CartId { get; set; }
    public int Quantity { get; set; }
    // Thêm giá để đảm bảo là giá có thể thay đổi tùy vào chương trình giảm giá
    public int Price_At_Purchase { get; set; }
    // cart-cart.detail
    public virtual required Cart Cart { get; set; }
    // cart-detail - product
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
}
