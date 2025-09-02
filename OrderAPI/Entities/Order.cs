namespace OrderAPI.Entities
{
    //Agregado
    public class Order
    {
        //Field
        private List<OrderItem> _orderItem= new List<OrderItem>();
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public Address ShippingAddress { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            _orderItem.Add(item);
            TotalAmount += item.TotalPrice;
        }

        public void RemoveOrderItem(OrderItem item)
        {
            var existingItem = _orderItem.FirstOrDefault(i => i.ID == item.ID);
            if (existingItem!=null)
            {
                _orderItem.Remove(item);
                TotalAmount -= item.TotalPrice;
            }
        }

    }
}
