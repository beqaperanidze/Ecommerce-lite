using EcommerceLite.Models;

namespace EcommerceLite.Services.Interfaces;

public interface ICustomAuthorizationService
{
    Task<User?> Register(string username, string email, string password);
    Task<string?> Login(string identifier, string password);
}