using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;

namespace ProductAPI.Data
{
    public class ProductDBContext : DbContext
    {
        //fields

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
