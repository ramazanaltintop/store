using DataAccess.Abstract;
using DataAccess.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Extensions;
using Entities.Concrete;
using Entities.RequestParameters;

namespace DataAccess.Repositories.EntityFramework
{
    public sealed class EfCoreProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public EfCoreProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Delete(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
        {
            return _context
                .Products
                .FilteredByCategoryId(parameters.CategoryId)
                .FilteredBySearchTerm(parameters.SearchTerm)
                .FilteredByPrice(parameters.MinPrice, parameters.MaxPrice, parameters.IsValidPrice)
                .ToPaginate(parameters.PageNumber, parameters.PageSize);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product product) => Update(product);
    }
}