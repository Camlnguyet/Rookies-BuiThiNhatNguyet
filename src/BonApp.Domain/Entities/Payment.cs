using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class Payment
{
    [Key]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Required]
    public decimal Amount { get; set; }
    [Required]
    public required string PaymentMethod { get; set; }
    [Required]
    public required DateTime PaymentDate { get; set; }
    [Required]
    public required string Status { get; set; }
    public virtual Order Order { get; set; }
}
