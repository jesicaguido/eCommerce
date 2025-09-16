using ProductDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Interfaces
{
    /// <summary>
    /// Repository contract for accessing and manipulating Product aggregate roots.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a single product by its identifier.
        /// Returns <c>null</c> if no product matches the given id.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The matching product or <c>null</c>.</returns>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Returns all products stored in the database.
        /// </summary>
        /// <returns>An enumerable collection of products.</returns>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Determines whether a product with the specified name already exists.
        /// Useful to ensure uniqueness before inserting or updating.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <returns><c>true</c> if a product with the same name exists; otherwise <c>false</c>.</returns>
        Task<bool> ExistsByNameAsync(string name);

        /// <summary>
        /// Persists a new product to the database.
        /// </summary>
        /// <param name="entity">The product entity to add.</param>
        /// <returns>The saved entity with its generated identifier.</returns>
        Task<Product> AddAsync(Product entity);

        /// <summary>
        /// Persists modifications made to an existing product.
        /// The caller should fetch the entity, modify its properties and then call UpdateAsync.
        /// </summary>
        /// <param name="entity">The product with updated values.</param>
        Task UpdateAsync(Product entity);

        /// <summary>
        /// Removes a product from the database.
        /// The caller should fetch the entity first and then call DeleteAsync.
        /// </summary>
        /// <param name="entity">The product to delete.</param>
        Task DeleteAsync(Product entity);
    }
}