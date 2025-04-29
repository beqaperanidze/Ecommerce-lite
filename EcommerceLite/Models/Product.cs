using System.ComponentModel.DataAnnotations;

namespace EcommerceLite.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}