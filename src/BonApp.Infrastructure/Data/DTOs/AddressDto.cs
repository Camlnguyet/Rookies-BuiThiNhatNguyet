namespace BonApp.Infrastructure.Data.DTOs;

public class AddressDto
{
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Ward { get; set; } = default!;
    public string? Street { get; set; }
    public string? HouseNumber { get; set; }
}
