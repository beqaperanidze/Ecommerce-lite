using EcommerceLite.DTOs;
using EcommerceLite.Models;

namespace EcommerceLite.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductReadDto>> GetAllProductsAsync();
    Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(int categoryId);
    Task<ProductReadDto?> GetProductByIdAsync(int id);
    Task<ProductReadDto> CreateProductAsync(ProductCreateDto productDto);
    Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<ProductReadDto>> SearchProductsAsync(string searchTerm);
}