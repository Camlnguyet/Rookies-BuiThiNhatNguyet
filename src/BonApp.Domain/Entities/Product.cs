

namespace BonApp.Domain.Entities;

public class Product : BaseEntity
{
    public required string ProductName { get; set; }
    public string ProductDescription { get; set; } = default!;
    public required decimal Price { get; set; }
    public required string Status { get; set; } = default!;
    public DateTimeOffset DateProduce { get; set; } = DateTime.UtcNow;
    // số ngày sản phẩm sử dụng được
    public required int DateUse { get; set; }
    // product-category
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
    // orderdetail - product
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    // review-product
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    // cart-detail - product
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
}
