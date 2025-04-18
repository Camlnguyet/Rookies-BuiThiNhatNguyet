using BonApp.Application.Interfaces;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace BonApp.Application.Services;

public class AuthService : IAuthService
{
    // private readonly AppDbContext _context;
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config, IUserRepository userRepository)
    {
        // _context = context;
        _userRepository = userRepository;
        _config = config;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        if (await _userRepository.Users.AnyAsync(x => x.Email == dto.Email))
            return false;

        var user = new User
        {
            UserName = dto.UserName,
            Email = dto.Email,
            LastName = dto.LastName,
            FirstName = dto.FirstName,
            PhoneNumber = dto.PhoneNumber,
            Role = "User",
            // Mật khẩu đã được mã hóa
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _userRepository.Add(user);
        await _userRepository.UnitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.Users.SingleOrDefaultAsync(x => x.Email == dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        var token = GenerateJwtToken(user);
        return new AuthResponseDto
        {
            Token = token,
            Email = user.Email,
            UserName = user.UserName
        };
    }

    public async Task<User> GetCurrentUserAsync(ClaimsPrincipal userClaims)
    {
        var email = userClaims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        return await _userRepository.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:ExpireMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
