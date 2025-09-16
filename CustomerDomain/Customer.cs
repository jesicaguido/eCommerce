using System;

namespace CustomerDomain
{
    /// <summary>
    /// Aggregate root representing a customer in the system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier of the customer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the customer.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the physical address of the customer.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the date on which the customer registered.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
    }
}