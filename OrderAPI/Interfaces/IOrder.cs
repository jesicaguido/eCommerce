namespace OrderAPI.Interfaces
{
    public interface IOrder
    {
        public bool AddOrder(string description);
        public bool RemoveOrder(int id); 
        public bool UpdateOrder(int id);
        public string GetOrder(int id);     
    }
}
