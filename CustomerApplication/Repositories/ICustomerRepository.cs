using CustomerDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerAPI.Interfaces
{
    /// <summary>
    /// Repository contract for accessing and manipulating Customer aggregates.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves a customer by its identifier.
        /// </summary>
        Task<Customer?> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// Determines whether a customer already exists with the specified email.
        /// </summary>
        Task<bool> ExistsByEmailAsync(string email);

        /// <summary>
        /// Persists a new customer in the data store.
        /// </summary>
        Task<Customer> AddAsync(Customer entity);

        /// <summary>
        /// Persists updates to an existing customer.
        /// </summary>
        Task UpdateAsync(Customer entity);

        /// <summary>
        /// Removes a customer from the data store.
        /// </summary>
        Task DeleteAsync(Customer entity);
    }
}
