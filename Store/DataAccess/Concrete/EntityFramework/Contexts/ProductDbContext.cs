using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { ProductId = 1, ProductName = "Computer", Price = 24_000 },
                new Product { ProductId = 2, ProductName = "Keyboard", Price = 1_000 },
                new Product { ProductId = 3, ProductName = "Mouse", Price = 600 },
                new Product { ProductId = 4, ProductName = "Monitor", Price = 10_000 },
                new Product { ProductId = 5, ProductName = "Deck", Price = 2_500 }
            );
        }
    }
}