using CustomerDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data
{
    /// <summary>
    /// Entity Framework Core DbContext for the Customer microservice.
    /// Defines the Customers table and configures basic constraints.
    /// </summary>
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                // Ensure email uniqueness at the database level
                entity.HasIndex(e => e.Email).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
    }
    
}
