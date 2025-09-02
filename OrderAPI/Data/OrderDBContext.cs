using OrderAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Data
{
    public class OrderDBContext: DbContext
    {    

        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);
            base.OnModelCreating(modelBuilder);

        }
    }
}
