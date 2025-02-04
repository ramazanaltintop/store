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

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice)
                return products.Where(product => product.Price >= minPrice && product.Price <= maxPrice);
            else
                return products;
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products,
            int pageNumber, int pageSize)
        {
            return products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}