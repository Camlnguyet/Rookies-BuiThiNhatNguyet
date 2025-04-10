using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace BonApp.Domain.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public required string ProductName { get; set; }
    public string ProductDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime DateProduce { get; set; }
    // số ngày sản phẩm sử dụng được
    [Required]
    public required int DateUse { get; set; }
    // product-category
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    // orderdetail - product
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    // review-product
    public virtual ICollection<Review> Reviews { get; set; }
    // cart-detail - product
    public virtual ICollection<CartDetail> CartDetails { get; set; }
    public Product()
    {
        Reviews = new HashSet<Review>();
        OrderDetails = new HashSet<OrderDetail>();
        CartDetails = new HashSet<CartDetail>();
    }
}
