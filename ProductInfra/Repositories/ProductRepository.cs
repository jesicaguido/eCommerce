using ProductAPI.Interfaces;
using ProductDomain;

namespace ProductAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        public bool AddProduct(string name)
        {
            return true;
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public string GetProduct(int id)
        {
            return "Prouduct";
        }
      

        public bool RemoveProduct(int id)
        {
            return true;
        }

        public bool UpdateProduct(int id)
        {
            return true;
        }
    }
}
