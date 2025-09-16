using ProductApplication.DTO;
using ProductDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApplication.Services
{
    /// <summary>
    /// Service contract encapsulating business rules for managing products.
    /// Delegates persistence to an underlying repository.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Retrieves a product by its identifier.
        /// </summary>
        /// <param name="id">Identifier of the product to retrieve.</param>
        /// <returns>A <see cref="ProductResult{T}"/> containing the product or an error message.</returns>
        Task<ProductResult<Product>> GetByIdAsync(int id);

        /// <summary>
        /// Returns all products.
        /// </summary>
        /// <returns>A <see cref="ProductResult{T}"/> containing a collection of products.</returns>
        Task<ProductResult<IEnumerable<Product>>> GetAllAsync();

        /// <summary>
        /// Creates a new product based on the supplied data transfer object.
        /// Performs validation and uniqueness checks before persisting.
        /// </summary>
        /// <param name="dto">The values for the new product.</param>
        /// <returns>A <see cref="ProductResult{T}"/> containing the created product or an error message.</returns>
        Task<ProductResult<Product>> CreateAsync(CreateProductDto dto);

        /// <summary>
        /// Updates an existing product with new values.
        /// Only the provided fields will be updated; missing fields remain unchanged.
        /// </summary>
        /// <param name="id">Identifier of the product to update.</param>
        /// <param name="dto">The values to update.</param>
        /// <returns>A <see cref="ProductResult{T}"/> containing the updated product or an error.</returns>
        Task<ProductResult<Product>> UpdateAsync(int id, UpdateProductDto dto);

        /// <summary>
        /// Deletes a product identified by the given identifier.
        /// </summary>
        /// <param name="id">Identifier of the product to remove.</param>
        /// <returns>A <see cref="ProductResult{T}"/> containing <c>true</c> on success or an error message.</returns>
        Task<ProductResult<bool>> DeleteAsync(int id);
    }
}