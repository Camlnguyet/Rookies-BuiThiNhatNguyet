namespace BonApp.Infrastructure.Data.DTOs;

// Nhập thông tin để tạo tài khoản - cus
public class RegisterDto
{
    public string UserName { get; set; }
    public string Email { get; set;}
    public string Password { get; set;}
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string PhoneNumber   { get; set;}
}
