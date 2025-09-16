using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.DTO
{
    public record CreateCustomerDto(string Name, string Email, string? Address, DateTime RegistrationDate);
}
