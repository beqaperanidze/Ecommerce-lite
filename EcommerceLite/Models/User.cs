﻿using System.ComponentModel.DataAnnotations;
using EcommerceLite.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [EnumDataType(typeof(Role))]
    public Role Role { get; set; } = Role.User;
}