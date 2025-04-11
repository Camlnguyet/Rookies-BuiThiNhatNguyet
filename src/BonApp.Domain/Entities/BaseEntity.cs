namespace BonApp.Domain.Entities;

public abstract class BaseEntity
{
    //  thừa kế hết tất cả entity
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTime.UtcNow;
}
