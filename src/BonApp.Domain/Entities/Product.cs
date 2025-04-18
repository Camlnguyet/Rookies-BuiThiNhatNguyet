

namespace BonApp.Domain.Entities;

public class Product : BaseEntity
{
    public string ProductName { get; set; } = default!;
    public string ProductDescription { get; set; } = default!;
    public int Price { get; set; }
    public string Status { get; set; } = default!;
    public DateTimeOffset DateProduce { get; set; } = DateTime.UtcNow;
    // số ngày sản phẩm sử dụng được
    public int DateUse { get; set; }
    // product-category
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
    // orderdetail - product
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
    // review-product
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    // cart-detail - product
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
    public virtual ICollection<ImageProduct> ImageProducts { get; set; } = new HashSet<ImageProduct>();
}
