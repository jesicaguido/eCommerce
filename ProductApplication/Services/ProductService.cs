using ProductAPI.Interfaces;
using ProductApplication.DTO;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProductResult<Product>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return ProductResult.Fail<Product>("Id inválido.");

            var product = await _repo.GetByIdAsync(id);

            if (product is null)
                return ProductResult.Fail<Product>("Producto no encontrado.");

            return ProductResult.Success(product);
        }

        public async Task<ProductResult<Product>> CreateAsync(CreateProductDto dto)
        {
            // Validaciones de aplicación (sin excepciones):
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ProductResult.Fail<Product>("El nombre es obligatorio.");

            if (dto.Price < 0)
                return ProductResult.Fail<Product>("El precio no puede ser negativo.");

            if (dto.Stock < 0)
                return ProductResult.Fail<Product>("El stock no puede ser negativo.");

            // Regla simple de unicidad (opcional):
            if (await _repo.ExistsByNameAsync(dto.Name.Trim()))
                return ProductResult.Fail<Product>("Ya existe un producto con ese nombre.");

            // Mapping manual DTO -> Entidad
            var entity = new Product
            {
                Name = dto.Name.Trim(),
                Description = dto.Description?.Trim(),
                Price = dto.Price,
                Stock = dto.Stock
            };

            var created = await _repo.AddAsync(entity);

            // Éxito
            return ProductResult.Success(created);
        }
    }

}
