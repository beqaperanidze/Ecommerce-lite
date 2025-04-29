using AutoMapper;
using EcommerceLite.Data;
using EcommerceLite.DTOs;
using EcommerceLite.Models;
using EcommerceLite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Services.Implementations;

public class ProductService(ApplicationDbContext context, IMapperBase mapper) : IProductService
{
    public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync()
    {
        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        return mapper.Map<IEnumerable<ProductReadDto>>(products);
    }

    public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();

        return mapper.Map<IEnumerable<ProductReadDto>>(products);
    }

    public async Task<ProductReadDto?> GetProductByIdAsync(int id)
    {
        var product = await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product != null ? mapper.Map<ProductReadDto>(product) : null;
    }

    public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto productDto)
    {
        var product = mapper.Map<Product>(productDto);
        context.Products.Add(product);
        await context.SaveChangesAsync();

        var createdProduct = context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        return mapper.Map<ProductReadDto>(createdProduct);
    }

    public async Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        mapper.Map(productDto, product);
        product.Id = id;

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        context.Products.Remove(product);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<IEnumerable<ProductReadDto>> SearchProductsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAllProductsAsync();
        }

        var products = await context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .Include(p => p.Category)
            .ToListAsync();
        
        return mapper.Map<IEnumerable<ProductReadDto>>(products); 
    }
}