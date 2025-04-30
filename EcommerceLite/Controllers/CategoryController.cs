using EcommerceLite.DTOs;
using EcommerceLite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceLite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return category != null ? Ok(category) : NotFound();
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<CategoryDto>> GetCategoryByName(string name)
    {
        var category = await _categoryService.GetCategoryByNameAsync(name);
        return category != null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
    {
        var category = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDto categoryDto)
    {
        var result = await _categoryService.UpdateCategoryAsync(id, categoryDto);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var result = await _categoryService.DeleteCategoryAsync(id);
        return result ? NoContent() : NotFound();
    }
}