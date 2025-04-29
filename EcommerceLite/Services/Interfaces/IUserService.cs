using EcommerceLite.DTOs;
    
    namespace EcommerceLite.Services.Interfaces;
    
    /// <summary>
    /// Interface for user-related operations in the e-commerce application.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="UserReadDto"/>.</returns>
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
    
        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="UserReadDto"/> if found, otherwise null.</returns>
        Task<UserReadDto?> GetUserByIdAsync(int id);
    
        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="UserReadDto"/> if found, otherwise null.</returns>
        Task<UserReadDto?> GetUserByUsernameAsync(string username);
    
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email">The email address of the user.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="UserReadDto"/> if found, otherwise null.</returns>
        Task<UserReadDto?> GetUserByEmailAsync(string email);
    
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userDto">The data transfer object containing user registration details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="UserReadDto"/>.</returns>
        Task<UserReadDto> CreateUserAsync(UserRegisterDto userDto);
    
        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="userDto">The data transfer object containing updated user details.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the update was successful.</returns>
        Task<bool> UpdateUserAsync(int id, UserRegisterDto userDto);
    
        /// <summary>
        /// Deletes a user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
        Task<bool> DeleteUserAsync(int id);
    }