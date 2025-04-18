using BonApp.Application.Interfaces;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using BonApp.Infrastructure.Hasing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonApp.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;
    private readonly IUserService _userService;
    private readonly IAddressRepository _addressRepository;
    public AddressController(IAddressService addressService, IUserService userService, IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
        _addressService = addressService;
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> AddAddress([FromBody] AddressDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var address = await _addressService.CreateAddressAsync(dto);
        if (address == null)
        {
            // Check if user exists first
            var user = await _userService.GetUserByIdAsync(dto.UserId);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            return BadRequest("Address already exists for this user");
        }
        return Ok(dto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AddressDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses()
    {
        var addresses = await _addressService.GetAllAddressesAsync();
        return Ok(addresses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDto>> GetAddressByIdAsync(int id)
    {
        var address = await _addressService.GetAddressByIdAsync(id);
        return Ok(address);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteIdAddress(int id)
    {
        var address = await _addressRepository.Addresses.FirstOrDefaultAsync(p => p.Id == id);
        if (address == null)
        {
            return NotFound("Address not found");
        }
        _addressRepository.Delete(address);
        await _addressRepository.SaveChangesAsync();
        return Ok(new { Message = "Address deleted successfully" });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AddressDto>> UpdateAddressByIdAsync(int id, [FromBody] AddressDto dto)
    {
        var address = await _addressRepository.Addresses.FirstOrDefaultAsync(p => p.Id == id);
        if (address == null)
        {
            return NotFound("Address not found");
        }
        address.City = dto.City;
        address.District = dto.District;
        address.Street = dto.Street;
        address.Ward = dto.Ward;
        address.HouseNumber = dto.HouseNumber;
        address.UserId = dto.UserId;
        address.HashKey = AddressHasher.GenerateHash(address);

        await _addressRepository.SaveChangesAsync();
        return Ok(new { Message = "Address update successfully" });
    }
}
