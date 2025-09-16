using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.DTO
{
    public record CreateProductDto(string Name, string? Description, decimal Price, int Stock);

}
