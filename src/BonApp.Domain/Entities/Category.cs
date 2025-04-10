using System;
using System.ComponentModel.DataAnnotations;
namespace BonApp.Domain.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public required string CategoryName { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public required DateTime CreateAt { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}
