using OrderCore;

namespace OrderDomain.Models.Entities
{
    public class OrderItem : OrderEntity
    {
              
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
