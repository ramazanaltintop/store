using DataAccess.Abstract;
using DataAccess.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EntityFramework
{
    public class EfCoreProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public EfCoreProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Delete(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters parameters)
        {
            return parameters.CategoryId is null
                ? _context
                    .Products
                    .Include(product => product.Category)
                : _context
                    .Products
                    .Include(product => product.Category)
                    .Where(product => product.CategoryId.Equals(parameters.CategoryId));
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