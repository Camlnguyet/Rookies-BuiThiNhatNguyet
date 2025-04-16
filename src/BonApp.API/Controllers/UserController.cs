using BonApp.Application.Interfaces;
using BonApp.Application.Services;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BonApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;

    public UserController(IUserService userService, IUserRepository userRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var Users = await _userService.GetAllUsersAsync();
        return Ok(Users);
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] UserDto dto)
    {
        var user = await _userService.CreateUserAsync(dto);
        if (user == null)
        {
            return BadRequest("User is existed.");
        }
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return BadRequest("Not Found");
        }
        return user;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDto>> DeleteUserByIdAsync(int id)
    {
        var user = await _userRepository.Users.FirstOrDefaultAsync(p => p.Id == id);
        if (user == null)
        {
            return BadRequest("Not Found");
        }
        _userRepository.Delete(user);
        await _userRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(AddUser), new { }, new { user, Message = "User deleted successful." });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateFullUserAsync(int id, [FromBody] UpdateUserDto dto)
    {
        var user = await _userRepository.Users.FirstOrDefaultAsync(p => p.Id == id);
        if (user == null)
        {
            return BadRequest("Not Found");
        }
        // khúc này vẫn chưa chặt chẽ lắm
        if (await _userService.IsUserExistAsync(dto.Email))
        {
            return BadRequest("Email after update is existed.");
        }

        user.LastName = dto.LastName;
        user.FirstName = dto.FirstName;
        user.Email = dto.Email;
        user.UserName = dto.UserName;
        user.Password = dto.Password;
        user.PhoneNumber = dto.PhoneNumber;

        await _userRepository.SaveChangesAsync();
        return CreatedAtAction(nameof(AddUser), new { }, new { user, Message = "User update successful." });
    }
}
