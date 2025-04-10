using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }
    [Required]
    public required int Quantity { get; set; }
    [Required]
    public required decimal Price_At_Purchase { get; set; }

    // order-orderDetail
    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual required Order Order { get; set; }

    // orderDetail-product
    [ForeignKey("Product")]
    [Required]
    public int ProductId { get; set; }
    public virtual required Product Product { get; set; }
}
