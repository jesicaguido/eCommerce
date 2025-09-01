using ProductAPI.Interfaces;

namespace ProductAPI.Services
{
    public class DBProduct : IDBProduct
    {
        public bool AddProduct(string name)
        {
            return true;
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
