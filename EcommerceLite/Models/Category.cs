using System.ComponentModel.DataAnnotations;
using EcommerceLite.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    public List<Product> Products { get; set; }
}