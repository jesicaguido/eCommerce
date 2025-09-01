using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuraciones avanzadas de las entidades    

            base.OnModelCreating(modelBuilder);
        }
    }
}
