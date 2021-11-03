using Microsoft.EntityFrameworkCore;


namespace Test.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
    }
}