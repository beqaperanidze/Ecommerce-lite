using AutoMapper;
using EcommerceLite.Models;
using EcommerceLite.DTOs;

namespace EcommerceLite.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDto>();
        CreateMap<UserRegisterDto, User>();
    }
}