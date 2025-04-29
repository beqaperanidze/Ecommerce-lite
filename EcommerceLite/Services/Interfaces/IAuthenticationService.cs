using EcommerceLite.DTOs;

namespace EcommerceLite.Services.Interfaces;

public interface IAuthenticationService
{
    Task<(UserReadDto? User, string? Token)> AuthenticateAsync(UserLoginDto loginDto);
    Task<bool> ValidateTokenAsync(string token);
    Task<UserReadDto?> GetUserFromTokenAsync(string token);
}