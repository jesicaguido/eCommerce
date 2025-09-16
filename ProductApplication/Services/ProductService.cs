using ProductAPI.Interfaces;
using ProductApplication.DTO;
using ProductDomain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApplication.Services
{
    /// <summary>
    /// Implements product-related business logic, handling validation and
    /// delegating persistence to the repository layer. Uses a result pattern
    /// to return either a value or an error message.
    /// </summary>
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

        public async Task<ProductResult<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return ProductResult.Success<IEnumerable<Product>>(products);
        }

        public async Task<ProductResult<Product>> CreateAsync(CreateProductDto dto)
        {
            // Validations
            if (string.IsNullOrWhiteSpace(dto.Name))
                return ProductResult.Fail<Product>("El nombre es obligatorio.");
            if (dto.Price < 0)
                return ProductResult.Fail<Product>("El precio no puede ser negativo.");
            if (dto.Stock < 0)
                return ProductResult.Fail<Product>("El stock no puede ser negativo.");
            // Uniqueness check
            var trimmedName = dto.Name.Trim();
            if (await _repo.ExistsByNameAsync(trimmedName))
                return ProductResult.Fail<Product>("Ya existe un producto con ese nombre.");

            var entity = new Product
            {
                Name = trimmedName,
                Description = dto.Description?.Trim(),
                Price = dto.Price,
                Stock = dto.Stock
            };

            var created = await _repo.AddAsync(entity);
            return ProductResult.Success(created);
        }

        public async Task<ProductResult<Product>> UpdateAsync(int id, UpdateProductDto dto)
        {
            if (id <= 0)
                return ProductResult.Fail<Product>("Id inválido.");

            var product = await _repo.GetByIdAsync(id);
            if (product is null)
                return ProductResult.Fail<Product>("Producto no encontrado.");

            // Update name if provided and valid
            if (dto.Name != null && !string.IsNullOrWhiteSpace(dto.Name))
            {
                var trimmedName = dto.Name.Trim();
                if (!string.Equals(product.Name, trimmedName, StringComparison.OrdinalIgnoreCase) &&
                    await _repo.ExistsByNameAsync(trimmedName))
                {
                    return ProductResult.Fail<Product>("Ya existe un producto con ese nombre.");
                }
                product.Name = trimmedName;
            }

            // Update description if provided
            if (dto.Description != null)
            {
                product.Description = dto.Description.Trim();
            }

            // Update price if provided
            if (dto.Price.HasValue)
            {
                if (dto.Price.Value < 0)
                    return ProductResult.Fail<Product>("El precio no puede ser negativo.");
                product.Price = dto.Price.Value;
            }

            // Update stock if provided
            if (dto.Stock.HasValue)
            {
                if (dto.Stock.Value < 0)
                    return ProductResult.Fail<Product>("El stock no puede ser negativo.");
                product.Stock = dto.Stock.Value;
            }

            await _repo.UpdateAsync(product);
            return ProductResult.Success(product);
        }

        public async Task<ProductResult<bool>> DeleteAsync(int id)
        {
            if (id <= 0)
                return ProductResult.Fail<bool>("Id inválido.");

            var product = await _repo.GetByIdAsync(id);
            if (product is null)
                return ProductResult.Fail<bool>("Producto no encontrado.");

            await _repo.DeleteAsync(product);
            return ProductResult.Success<bool>(true);
        }
    }
}