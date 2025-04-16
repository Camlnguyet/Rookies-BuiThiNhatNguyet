using BonApp.Application.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BonApp.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public async Task<ActionResult> AddAddress([FromBody] AddressDto dto)
    {
        var address = await _addressService.CreateAddressAsync(dto);
        if (address == null)
        {
            return BadRequest("User is not available");
        }
        return Ok(address);
    }
}
