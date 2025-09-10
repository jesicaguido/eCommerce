using CustomerAPI.Interfaces;

namespace CustomerAPI.Services
{
    public class CustomerRepository : ICustomer
    {
        public bool AddCustomer(string name)
        {
            return true;
        }
        public string GetCustomer(int id)
        {
            return "Customer";
        }
        public bool RemoveCustomer(int id)
        {
            return true;
        }
        public bool UpdateCustomer(int id)
        {
            return true;
        }
    }
   
}
