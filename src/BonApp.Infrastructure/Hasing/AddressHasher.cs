using System.Security.Cryptography;
using System.Text;
using BonApp.Domain.Entities;

namespace BonApp.Infrastructure.Hasing;

public class AddressHasher
{
    public static string GenerateHash(Address address)
    {
        var normalized = $"{address.HouseNumber?.Trim().ToLower()}|{address.Street?.Trim().ToLower()}|{address.Ward?.Trim().ToLower()}|{address.District?.Trim().ToLower()}|{address.City?.Trim().ToLower()}";

        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(normalized);
        var hashBytes = sha256.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes); // hoặc Convert.ToBase64String(hashBytes)
    }
}