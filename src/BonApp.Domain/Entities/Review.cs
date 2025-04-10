using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class Review
{
    //  review_id integer [primary key]
    //   user_id integer
    //   product_id integer
    //   rating integer [note:"Giới hạn 5 sao"]
    //   comment varchar
    //   created_at timestamp
    [Key]
    public int ReviewId { get; set; }
    [Required]
    public required int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    // review - user
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    // review-product
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}
