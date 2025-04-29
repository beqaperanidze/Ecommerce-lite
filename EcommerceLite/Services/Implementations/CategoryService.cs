using AutoMapper;
using EcommerceLite.Data;
using EcommerceLite.DTOs;
using EcommerceLite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Services.Implementations;

public class CategoryService(ApplicationDbContext context, IMapper mapper)
    : ICategoryService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        return category != null ? _mapper.Map<CategoryDto>(category) : null;
    }

    public async Task<CategoryDto?> GetCategoryByNameAsync(string name)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        return category != null ? _mapper.Map<CategoryDto>(category) : null;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _mapper.Map(categoryDto, category);
        category.Id = id;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}