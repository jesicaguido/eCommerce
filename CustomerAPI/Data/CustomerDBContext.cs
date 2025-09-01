using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Data
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options) : base(options)
        {
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuraciones avanzadas de las entidades    
            base.OnModelCreating(modelBuilder);
        }
    }
    {
    }
}
