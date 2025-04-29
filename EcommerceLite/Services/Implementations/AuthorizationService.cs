using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using EcommerceLite.Data;
using EcommerceLite.Models;
using EcommerceLite.Services.Interfaces;

namespace EcommerceLite.Services.Implementations;

public class AuthorizationService(ApplicationDbContext context, IJwtService jwtService) : ICustomAuthorizationService
{
    private readonly IJwtService _jwtService = jwtService;
    private readonly ApplicationDbContext _context = context;

    public async Task<User?> Register(string username, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            return null;
        }

        if (await _context.Users.AnyAsync(u => u.Username == username))
        {
            return null; 
        }

        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            return null; 
        }

        var passwordHash = HashPassword(password);

        var newUser = new User
        {
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            Role = Role.User 
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return newUser;
    }

    public async Task<string?> Login(string identifier, string password)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == identifier || u.Email == identifier);

        if (user == null)
        {
            return null; 
        }

        return !VerifyPassword(password, user.PasswordHash) ? null :
            _jwtService.GenerateToken(user.Username, user.Role.ToString());
    }

    private static string HashPassword(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    private static bool VerifyPassword(string password, string hashedPassword)
    {
        var hashedInputBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var hashedInputString = Convert.ToBase64String(hashedInputBytes);
        return hashedInputString == hashedPassword;
    }
}