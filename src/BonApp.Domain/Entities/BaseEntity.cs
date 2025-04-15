

using System.ComponentModel.DataAnnotations;

namespace BonApp.Domain.Entities;

public abstract class BaseEntity
{
    //  thừa kế hết tất cả entity
    // [Key]
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTime.UtcNow;
}
