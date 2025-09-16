using CustomerAPI.Interfaces;
using CustomerApplication.DTO;
using CustomerDomain;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerApplication.Services
{
    /// <summary>
    /// Implements customer-related business logic, handling validations and
    /// delegating data access to the repository layer.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<CustomerResult<Customer>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return CustomerResult.Fail<Customer>("Id inválido.");

            var customer = await _repo.GetByIdAsync(id);
            if (customer is null)
                return CustomerResult.Fail<Customer>("Cliente no encontrado.");

            return CustomerResult.Success(customer);
        }

        public async Task<CustomerResult<IEnumerable<Customer>>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            return CustomerResult.Success<IEnumerable<Customer>>(customers);
        }

        public async Task<CustomerResult<Customer>> CreateAsync(CreateCustomerDto dto)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(dto.Name))
                return CustomerResult.Fail<Customer>("El nombre es obligatorio.");
            // Validate email
            if (string.IsNullOrWhiteSpace(dto.Email) || !IsValidEmail(dto.Email))
                return CustomerResult.Fail<Customer>("El correo electrónico no es válido.");
            // Check uniqueness
            var trimmedEmail = dto.Email.Trim();
            if (await _repo.ExistsByEmailAsync(trimmedEmail))
                return CustomerResult.Fail<Customer>("Ya existe un cliente con ese correo electrónico.");

            var entity = new Customer
            {
                Name = dto.Name.Trim(),
                Email = trimmedEmail,
                Address = dto.Address?.Trim(),
                RegistrationDate = dto.RegistrationDate
            };

            var created = await _repo.AddAsync(entity);
            return CustomerResult.Success(created);
        }

        public async Task<CustomerResult<Customer>> UpdateAsync(int id, UpdateCustomerDto dto)
        {
            if (id <= 0)
                return CustomerResult.Fail<Customer>("Id inválido.");

            var customer = await _repo.GetByIdAsync(id);
            if (customer is null)
                return CustomerResult.Fail<Customer>("Cliente no encontrado.");

            // Update name
            if (dto.Name != null && !string.IsNullOrWhiteSpace(dto.Name))
            {
                customer.Name = dto.Name.Trim();
            }

            // Update email
            if (dto.Email != null && !string.IsNullOrWhiteSpace(dto.Email))
            {
                var trimmedEmail = dto.Email.Trim();
                if (!IsValidEmail(trimmedEmail))
                    return CustomerResult.Fail<Customer>("El correo electrónico no es válido.");
                if (!string.Equals(customer.Email, trimmedEmail, StringComparison.OrdinalIgnoreCase) &&
                    await _repo.ExistsByEmailAsync(trimmedEmail))
                {
                    return CustomerResult.Fail<Customer>("Ya existe un cliente con ese correo electrónico.");
                }
                customer.Email = trimmedEmail;
            }

            // Update address
            if (dto.Address != null)
            {
                customer.Address = dto.Address.Trim();
            }

            // Update registration date (rarely changes, but allowed)
            if (dto.RegistrationDate.HasValue)
            {
                customer.RegistrationDate = dto.RegistrationDate.Value;
            }

            await _repo.UpdateAsync(customer);
            return CustomerResult.Success(customer);
        }

        public async Task<CustomerResult<bool>> DeleteAsync(int id)
        {
            if (id <= 0)
                return CustomerResult.Fail<bool>("Id inválido.");

            var customer = await _repo.GetByIdAsync(id);
            if (customer is null)
                return CustomerResult.Fail<bool>("Cliente no encontrado.");

            await _repo.DeleteAsync(customer);
            return CustomerResult.Success<bool>(true);
        }

        /// <summary>
        /// Performs a basic email format check using a simple regular expression.
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            // Basic pattern for demonstration; consider using more robust validation in production
            const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }
    }
}