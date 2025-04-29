using AutoMapper;
using EcommerceLite.Data;
using EcommerceLite.DTOs;
using EcommerceLite.Models;
using EcommerceLite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Services.Implementations;

public class ProductService(ApplicationDbContext context, IMapperBase mapper) : IProductService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapperBase _mapper = mapper;
    public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync()
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductReadDto>>(products);
    }

    public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(int categoryId)
    {
        var products = await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductReadDto>>(products);
    }

    public async Task<ProductReadDto?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product != null ? _mapper.Map<ProductReadDto>(product) : null;
    }

    public async Task<ProductReadDto> CreateProductAsync(ProductCreateDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var createdProduct = _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == product.Id);

        return _mapper.Map<ProductReadDto>(createdProduct);
    }

    public async Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _mapper.Map(productDto, product);
        product.Id = id;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }

        _context.Products.Remove(product);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<IEnumerable<ProductReadDto>> SearchProductsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return await GetAllProductsAsync();
        }

        var products = await _context.Products
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .Include(p => p.Category)
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<ProductReadDto>>(products); 
    }
}