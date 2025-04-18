namespace BonApp.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    // không lưu trực tiếp password vào database => ẩn luôn cách mã hóa password
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!; // private 
    public string PhoneNumber { get; set; } = default!; //private 
    public int RoleId { get; set; }
    public virtual Role Role { get; set; } = default!;
    public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
}
