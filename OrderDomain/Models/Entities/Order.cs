using OrderCore;
using OrderDomain.Models.ValueObjects;

namespace OrderDomain.Models.Entities
{
    //Agregado
    public class Order : OrderEntity
    {
        //Field
        private List<OrderItem> _orderItems= new List<OrderItem>();
        
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItem> OrderItems
        {
            get { return _orderItems; }
            set { }
        }
        public Address ShippingAddress { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            _orderItems.Add(item);
            TotalAmount += item.UnitPrice + item.Quantity;
        }
        //

        public void RemoveOrderItem(OrderItem item)
        {
            var existingItem = _orderItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem!=null)
            {
                _orderItems.Remove(item);
                TotalAmount -= item.TotalPrice;
            }
        }

    }
}
