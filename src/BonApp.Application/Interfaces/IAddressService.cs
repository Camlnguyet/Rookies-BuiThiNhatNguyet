using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Interfaces;

public interface IAddressService
{
    Task<bool> IsAddressExistAsync(string addressHash);
    Task<Address?> CreateAddressAsync(AddressDto dto);
    Task<AddressDto?> GetAddressByIdAsync(int id);
    Task<IEnumerable<Address>> GetAllAddressesAsync();
    // Task<bool> DeleteAddressAsync(int id);
}
