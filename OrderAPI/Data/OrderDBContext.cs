using Microsoft.EntityFrameworkCore;
using OrderAPI.Entities;

namespace OrderAPI.Data
{
    public class OrderDBContext: DbContext
    {

        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
