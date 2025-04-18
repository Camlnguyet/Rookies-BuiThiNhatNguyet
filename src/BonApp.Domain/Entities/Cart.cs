namespace BonApp.Domain.Entities;

public class Cart : BaseEntity
{
    // Thêm phần này để khi các user không đăng nhập thì lấy một session key
    // token cookies cho mỗi phiên hoạt động -> khi tắt thì xóa sessionID
    // Xóa luôn cart (session storage)
    public int SessionId { get; set; }
    // cart-user
    public int UserId { get; set; }
    public virtual User User { get; set; }

    // cart-cart.detail
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
}
