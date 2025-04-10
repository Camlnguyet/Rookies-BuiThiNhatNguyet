using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class CartDetail
{
    [Key]
    public int CartDetailId { get; set; }
    [Required]
    public required int Quantity { get; set; }

    // cart-cart.detail
    [Required]
    [ForeignKey("Cart")]
    public int CartId { get; set; }
    public virtual required Cart Cart { get; set; }

    // cart-detail - product
    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
}
