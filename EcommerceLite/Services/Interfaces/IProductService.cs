using EcommerceLite.DTOs;

namespace EcommerceLite.Services.Interfaces;

/// <summary>
/// Interface for product-related operations in the e-commerce application.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="ProductReadDto"/>.</returns>
    Task<IEnumerable<ProductReadDto>> GetAllProductsAsync();

    /// <summary>
    /// Retrieves products by their category identifier.
    /// </summary>
    /// <param name="categoryId">The unique identifier of the category.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="ProductReadDto"/>.</returns>
    Task<IEnumerable<ProductReadDto>> GetProductsByCategoryAsync(int categoryId);

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="ProductReadDto"/> if found, otherwise null.</returns>
    Task<ProductReadDto?> GetProductByIdAsync(int id);

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="productDto">The data transfer object containing product details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="ProductReadDto"/>.</returns>
    Task<ProductReadDto> CreateProductAsync(ProductCreateDto productDto);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="productDto">The data transfer object containing updated product details.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the update was successful.</returns>
    Task<bool> UpdateProductAsync(int id, ProductCreateDto productDto);

    /// <summary>
    /// Deletes a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    Task<bool> DeleteProductAsync(int id);

    /// <summary>
    /// Searches for products based on a search term.
    /// </summary>
    /// <param name="searchTerm">The term to search for in product names or descriptions.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="ProductReadDto"/> matching the search term.</returns>
    Task<IEnumerable<ProductReadDto>> SearchProductsAsync(string searchTerm);
}