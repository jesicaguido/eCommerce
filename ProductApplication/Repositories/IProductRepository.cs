using ProductDomain;

namespace ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task<Product> AddAsync(Product entity);
        // Luego: UpdateAsync, DeleteAsync, GetAllAsync...

    }

}

