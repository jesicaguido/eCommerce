namespace ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        public bool AddProduct(string name);

        public bool RemoveProduct(int id);

        public bool UpdateProduct(int id);

       public string GetProduct(int id);

       
        
    }
}
