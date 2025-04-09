using System;
using System.ComponentModel.DataAnnotations;
namespace BonApp.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    public required string CategoryName { get; set; }
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}
