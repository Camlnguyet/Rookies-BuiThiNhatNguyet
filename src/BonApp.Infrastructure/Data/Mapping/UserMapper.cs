using AutoMapper;
using BonApp.Domain.Entities;
using BonApp.Infrastructure.Data.DTOs;

namespace BonApp.Infrastructure.Data.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, LoginDto>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
