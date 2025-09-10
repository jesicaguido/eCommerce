namespace CustomerAPI.Interfaces
{
    public interface ICustomerRepository
    {
        public bool AddCustomer(string name);
        public bool RemoveCustomer(int id); 
        public bool UpdateCustomer(int id);
        public string GetCustomer(int id);


    }
}
