namespace BonApp.Infrastructure.Data.DTOs;

public class UserDto
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string Password { get; set; } = default!;
}
