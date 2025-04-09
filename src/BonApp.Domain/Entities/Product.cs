using System.ComponentModel.DataAnnotations;

namespace BonApp.Domain.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public required string ProductName { get; set; }
    public string ProductDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime DateProduce { get; set; }
    public int CategoryId { get; set; }

    public virtual required Category Category { get; set; }
}
