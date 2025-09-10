namespace CustomerDomain.Models.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateOnly FechaRegistro { get; set; }
    }
}
