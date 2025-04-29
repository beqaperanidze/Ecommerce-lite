using System.ComponentModel.DataAnnotations;

namespace EcommerceLite.DTOs;

public class CategoryDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
}
