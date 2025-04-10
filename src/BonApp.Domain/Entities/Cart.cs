using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class Cart
{
    [Key]
    public int CartId { get; set; }
    [Required]
    public required DateTime CreatedAt { get; set; }

    // cart-user
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    // cart-cart.detail
    public virtual ICollection<CartDetail> CartDetails { get; set; }
    public Cart()
    {
        CartDetails = new HashSet<CartDetail>();
    }
}
