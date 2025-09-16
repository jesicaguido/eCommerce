using Microsoft.EntityFrameworkCore;
using ProductAPI.Interfaces;
using ProductAPI.Data;
using ProductDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    /// <summary>
    /// Concrete repository implementation backed by an EF Core DbContext.
    /// Provides asynchronous CRUD operations for the Product aggregate.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context;

        public ProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}