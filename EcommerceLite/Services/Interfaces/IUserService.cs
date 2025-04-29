using EcommerceLite.DTOs;

namespace EcommerceLite.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
    Task<UserReadDto?> GetUserByIdAsync(int id);
    Task<UserReadDto?> GetUserByUsernameAsync(string username);
    Task<UserReadDto?> GetUserByEmailAsync(string email);
    Task<UserReadDto> CreateUserAsync(UserRegisterDto userDto);
    Task<bool> UpdateUserAsync(int id, UserRegisterDto userDto);
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
    Task<bool> DeleteUserAsync(int id);
}