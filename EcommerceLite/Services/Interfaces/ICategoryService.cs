﻿using EcommerceLite.DTOs;

namespace EcommerceLite.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(int id);
    Task<CategoryDto?> GetCategoryByNameAsync(string name);
    Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto);
    Task<bool> DeleteCategoryAsync(int id);
}