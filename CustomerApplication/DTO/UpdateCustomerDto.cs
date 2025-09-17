using System;

namespace CustomerApplication.DTO
{
    /// <summary>
    /// Data Transfer Object used when updating an existing customer.
    /// Fields are nullable so only provided values will be updated.
    /// </summary>
    public record UpdateCustomerDto(string? Name, string? Email, string? Address, DateTime? RegistrationDate);
}
