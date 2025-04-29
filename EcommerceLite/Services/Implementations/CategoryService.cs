using AutoMapper;
using EcommerceLite.Data;
using EcommerceLite.DTOs;
using EcommerceLite.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Services.Implementations;

public class CategoryService(ApplicationDbContext context, IMapperBase mapper)
    : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await context.Categories.ToListAsync();
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await context.Categories.FindAsync(id);
        return category != null ? mapper.Map<CategoryDto>(category) : null;
    }

    public async Task<CategoryDto?> GetCategoryByNameAsync(string name)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        return category != null ? mapper.Map<CategoryDto>(category) : null;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        mapper.Map(categoryDto, category);
        category.Id = id;
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        context.Categories.Remove(category);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}