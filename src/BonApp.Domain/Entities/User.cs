namespace BonApp.Domain.Entities;

public class User : BaseEntity
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public required string Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public required string Role { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
}
