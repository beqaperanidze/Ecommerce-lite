using System.ComponentModel.DataAnnotations;

namespace EcommerceLite.DTOs;

public class ProductReadDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}

public class ProductCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
