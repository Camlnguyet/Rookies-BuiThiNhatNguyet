
namespace BonApp.Domain.Entities;

public class Category : BaseEntity
{
    public required string CategoryName { get; set; }
    public string Description { get; set; } = default!;
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
