using CustomerCore;

namespace CustomerDomain.Models.Entities
{
    public class Customer :CustomerEntity
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateOnly FechaRegistro { get; set; }
    }
}
