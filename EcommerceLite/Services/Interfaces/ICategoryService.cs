using EcommerceLite.DTOs;
    
    namespace EcommerceLite.Services.Interfaces;
    
    /// <summary>
    /// Interface for category-related operations in the e-commerce application.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="CategoryDto"/>.</returns>
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    
        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="CategoryDto"/> if found, otherwise null.</returns>
        Task<CategoryDto?> GetCategoryByIdAsync(int id);
    
        /// <summary>
        /// Retrieves a category by its name.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="CategoryDto"/> if found, otherwise null.</returns>
        Task<CategoryDto?> GetCategoryByNameAsync(string name);
    
        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="categoryDto">The data transfer object containing category details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="CategoryDto"/>.</returns>
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
    
        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="id">The unique identifier of the category to update.</param>
        /// <param name="categoryDto">The data transfer object containing updated category details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the update was successful.</returns>
        Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto);
    
        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
        Task<bool> DeleteCategoryAsync(int id);
    }