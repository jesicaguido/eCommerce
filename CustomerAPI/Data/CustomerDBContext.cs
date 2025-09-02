using CustomerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data
{
    public class CustomerDBContext : DbContext
    {
        //fields
        private string _maxLength = "100";

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
           
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
                entity.Property(e => e.Direccion)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
            });
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
