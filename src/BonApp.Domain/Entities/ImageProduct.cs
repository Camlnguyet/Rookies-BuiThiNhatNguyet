namespace BonApp.Domain.Entities;

public class ImageProduct : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string ImageUrl { get; set; } = default!;
}
