using Entities.Concrete;

namespace DataAccess.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,
            int? categoryId)
        {
            if (categoryId is null)
                return products;
            else
                return products.Where(product => product.CategoryId.Equals(categoryId));
        }

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
            String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            else
                return products.Where(product => product.ProductName.ToLower()
                    .Contains(searchTerm.ToLower()));
        }
    }
}