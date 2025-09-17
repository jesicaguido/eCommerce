using CustomerApplication.DTO;
using CustomerDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApplication.Services
{
    /// <summary>
    /// Service contract encapsulating business rules for managing customers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets a customer by identifier.
        /// </summary>
        Task<CustomerResult<Customer>> GetByIdAsync(int id);

        /// <summary>
        /// Gets all customers in the system.
        /// </summary>
        Task<CustomerResult<IEnumerable<Customer>>> GetAllAsync();

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        Task<CustomerResult<Customer>> CreateAsync(CreateCustomerDto dto);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        Task<CustomerResult<Customer>> UpdateAsync(int id, UpdateCustomerDto dto);

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        Task<CustomerResult<bool>> DeleteAsync(int id);
    }
}
