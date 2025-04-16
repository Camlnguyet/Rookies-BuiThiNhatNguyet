using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(UserDto dto);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<bool> IsUserExistAsync(string email);
}
