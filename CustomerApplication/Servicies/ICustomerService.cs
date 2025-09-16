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
        Task<CustomerResult<Customer>> GetByIdAsync(int id);
        Task<CustomerResult<IEnumerable<Customer>>> GetAllAsync();
        Task<CustomerResult<Customer>> CreateAsync(CreateCustomerDto dto);
        Task<CustomerResult<Customer>> UpdateAsync(int id, UpdateCustomerDto dto);
        Task<CustomerResult<bool>> DeleteAsync(int id);
    }
}