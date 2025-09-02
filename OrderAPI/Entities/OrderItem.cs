namespace OrderAPI.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }        
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
