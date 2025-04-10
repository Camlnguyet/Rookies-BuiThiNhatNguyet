using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required DateTime Order_Date { get; set; }

    [Required]
    public required int Quanity { get; set; }
    [Required]
    public required string Status { get; set; }
    [Required]
    public required decimal Price_At_Purchase { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public virtual Payment Payment { get; set; }
    public Order()
    {
        OrderDetails = new HashSet<OrderDetail>();
    }
}
