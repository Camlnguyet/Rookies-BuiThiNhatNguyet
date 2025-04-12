namespace BonApp.Infrastructure.Data.DTOs;

// Đăng nhập bằng email + mật khẩu - cus
// Xác thực admin
public class LoginDto
{
    public string UserName { get; set;}
    public string Password { get; set;}
}
