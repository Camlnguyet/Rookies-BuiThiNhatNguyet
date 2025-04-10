using System.ComponentModel.DataAnnotations;

namespace BonApp.Domain.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(30)]
    public required string UserName { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
    ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
    public required string Password { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có 10 chữ số.")]
    public string PhoneNumber { get; set; } = default!;

    [Required]
    [RegularExpression(@"^(Admin|User)$", ErrorMessage = "Role chỉ được phép là Admin hoặc là User")]
    public required string Role { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<Cart> Carts { get; set; }
    public User()
    {
        Addresses = new HashSet<Address>();
        Orders = new HashSet<Order>();
        Reviews = new HashSet<Review>();
        Carts = new HashSet<Cart>();
    }
}
