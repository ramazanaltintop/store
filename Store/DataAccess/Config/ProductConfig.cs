using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product { ProductId = 1, CategoryId = 2, ProductName = "Computer", Price = 24_000, ImageUrl = "/images/1.jpg", ShowCase = false },
                new Product { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 1_000, ImageUrl = "/images/2.jpg", ShowCase = false },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 600, ImageUrl = "/images/3.jpg", ShowCase = false },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Monitor", Price = 10_000, ImageUrl = "/images/4.jpg", ShowCase = false },
                new Product { ProductId = 5, CategoryId = 2, ProductName = "Deck", Price = 2_500, ImageUrl = "/images/5.jpg", ShowCase = false },
                new Product { ProductId = 6, CategoryId = 1, ProductName = "History", Price = 250, ImageUrl = "/images/6.jpg", ShowCase = false },
                new Product { ProductId = 7, CategoryId = 1, ProductName = "Theatre", Price = 2_500, ImageUrl = "/images/7.jpg", ShowCase = false },
                new Product { ProductId = 8, CategoryId = 1, ProductName = "A Doll's House", Price = 300, ImageUrl = "/images/8.jpg", ShowCase = true },
                new Product { ProductId = 9, CategoryId = 1, ProductName = "Blindness", Price = 400, ImageUrl = "/images/9.jpg", ShowCase = true },
                new Product { ProductId = 10, CategoryId = 1, ProductName = "Saadi's Bostan", Price = 225, ImageUrl = "/images/10.jpg", ShowCase = true }
            );
        }
    }
}