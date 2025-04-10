using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BonApp.Domain.Entities;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Street { get; set; }
    public required string Zip_code { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual required User User { get; set; }
}
