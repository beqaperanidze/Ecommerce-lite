using AutoMapper;
using EcommerceLite.Data;
using EcommerceLite.DTOs;
using EcommerceLite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Services.Implementations;

public class UserService(ApplicationDbContext context, Mapper mapper) : IUserService
{
    private readonly ApplicationDbContext _context = context;
    private readonly Mapper _mapper = mapper;


    public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public async Task<UserReadDto?> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user != null ? _mapper.Map<UserReadDto>(user) : null;
    }

    public async Task<UserReadDto?> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        return user != null ? _mapper.Map<UserReadDto>(user) : null;
    }

    public async Task<UserReadDto?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user != null ? _mapper.Map<UserReadDto>(user) : null;
    }

    public async Task<UserReadDto> CreateUserAsync(UserRegisterDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        _context.Add(user);
        await _context.SaveChangesAsync();

        var createdUser = _context.Users.FindAsync(user.Id);
        return _mapper.Map<UserReadDto>(createdUser);
    }

    public async Task<bool> UpdateUserAsync(int id, UserRegisterDto userDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _mapper.Map(userDto, user);
        user.Id = id;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}