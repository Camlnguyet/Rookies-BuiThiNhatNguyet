namespace BonApp.Domain.Entities;

public class Review : BaseEntity
{
    public int Rating { get; set; }
    public string Comment { get; set; } = default!;
    // review - user
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    // review-product
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
}
