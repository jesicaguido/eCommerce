using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data
{
    public class CustomerDBContext : DbContext
    {
        //fields

        //constructors
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }

        //properties
        public DbSet<Customer> Customers { get; set; }

        //methods
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuraciones avanzadas de las entidades    
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
