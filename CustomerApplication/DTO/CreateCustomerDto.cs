using System;

namespace CustomerApplication.DTO
{
    /// <summary>
    /// Data Transfer Object used when creating a new customer.
    /// </summary>
    public record CreateCustomerDto(string Name, string Email, string? Address, DateTime RegistrationDate);
}
