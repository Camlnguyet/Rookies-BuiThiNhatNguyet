

namespace BonApp.Domain.Entities;

public class Address : BaseEntity
{
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Ward { get; set; } = default!;
    public string? Street { get; set; }
    public string? HouseNumber { get; set; }
    public int UserId { get; set; }
    public virtual required User User { get; set; }
}
