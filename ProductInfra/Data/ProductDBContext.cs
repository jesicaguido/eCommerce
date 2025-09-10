using Microsoft.EntityFrameworkCore;
using ProductDomain.Models.Entities;
namespace ProductAPI.Data
{
    public class ProductDBContext : DbContext
    {
        //fields
        private string _maxLength="100";
        //constructors
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        //properties
        public DbSet<Product> Products { get; set; }

        //methods

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuraciones avanzadas de las entidades    

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
                entity.Property(e => e.Description)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
