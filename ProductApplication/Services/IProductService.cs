using ProductApplication.DTO;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Services
{
    public interface IProductService
    {
        Task<ProductResult<Product>> GetByIdAsync(int id);
        Task<ProductResult<Product>> CreateAsync(CreateProductDto dto);
        // Luego: UpdateAsync, DeleteAsync, GetAllAsync...
    }
}
