namespace OrderAPI.Interfaces
{
    public interface IOrderItemRepository
    {
        public bool AddOrderItem(int orderId, string itemName, int quantity);
        public bool RemoveOrderItem(int orderItemId);
        public bool UpdateOrderItem(int orderItemId, string itemName, int quantity);
        public string GetOrderItem(int orderItemId);
    }
}
