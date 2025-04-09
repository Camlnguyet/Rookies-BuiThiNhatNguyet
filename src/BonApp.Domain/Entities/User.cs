namespace BonApp.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Format("");
    public string Password { get; set; } = string.Format(@"");
    public string PhoneNumber { get; set; } = string.Format("");
}
