using AutoMapper;
using BonApp.Application.Interfaces;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using BonApp.Infrastructure.Hasing;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Application.Services;

public class AddressService : IAddressService
{
    private readonly IUserService _userService;
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    public AddressService(IUserService userService, IAddressRepository addressRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
        _addressRepository = addressRepository;
    }
    public async Task<Address?> CreateAddressAsync(AddressDto dto)
    {
        var user = await _userService.GetUserByIdAsync(dto.UserId);
        if (user == null)
        {
            return null;
        }
        var address = new Address
        {
            City = dto.City,
            District = dto.District,
            Ward = dto.Ward,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber,
            UserId = dto.UserId,

        };
        var hashAddress = AddressHasher.GenerateHash(address);
        if (await IsAddressExistAsync(hashAddress))
        {
            return null;
        }
        address.HashKey = hashAddress;
        await _addressRepository.CreateAsync(address);
        await _addressRepository.UnitOfWork.SaveChangesAsync();
        return address;
    }

    public async Task<bool> IsAddressExistAsync(string hashstring)
    {
        return await _addressRepository.Addresses.AnyAsync(p => p.HashKey == hashstring);
    }

    public async Task<AddressDto?> GetAddressByIdAsync(int id)
    {
        var address = await _addressRepository.Addresses.FirstOrDefaultAsync(p => p.Id == id);
        return address == null ? null : _mapper.Map<AddressDto>(address);
    }

    public async Task<IEnumerable<Address>> GetAllAddressesAsync()
    {
        return await _addressRepository.Addresses.ToListAsync();
    }

    // public async Task<bool> DeleteAddressAsync(int id)
    // {
    //     var address = await _addressRepository.Addresses.FirstOrDefaultAsync(p => p.Id == id);
    //     if (address == null)
    //     {
    //         return false;
    //     }
    //     _addressRepository.Delete(address);
    //     await _addressRepository.UnitOfWork.SaveChangesAsync();
    //     return true;
    // }
}
