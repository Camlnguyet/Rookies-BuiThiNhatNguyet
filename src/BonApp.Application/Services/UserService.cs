using AutoMapper;
using BonApp.Application.Interfaces;
using BonApp.Domain.Entities;
using BonApp.Domain.Interfaces;
using BonApp.Infrastructure.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.Users.ToListAsync();
    }
    public async Task<bool> IsUserExistAsync(string email)
    {
        return await _userRepository.Users.AnyAsync(e => e.Email == email);
    }
    public async Task<User?> CreateUserAsync(UserDto dto)
    {
        if (await IsUserExistAsync(dto.Email))
        {
            return null;
        }

        var user = new User
        {
            LastName = dto.LastName,
            FirstName = dto.FirstName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Role = dto.Role,
            UserName = dto.UserName,
            PasswordHash = dto.Password,
        };

        await _userRepository.CreateAsync(user);
        await _userRepository.UnitOfWork.SaveChangesAsync();
        return user;
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.Users.FirstOrDefaultAsync(p => p.Id == id);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }
}
