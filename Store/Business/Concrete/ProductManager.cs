using Business.Abstract;
using DataAccess.Coordinators;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IDalCoordinator _dalCoordinator;

        public ProductManager(IDalCoordinator dalCoordinator)
        {
            _dalCoordinator = dalCoordinator;
        }

        public IQueryable<Product> GetAllProducts(bool trackChanges)
        {
            return _dalCoordinator.Product.GetAll(trackChanges);
        }

        public Product GetProductById(int id, bool trackChanges)
        {
            var product = _dalCoordinator.Product.Get(p => p.ProductId.Equals(id), trackChanges);
            if (product is null)
            {
                throw new Exception("Product not found!");
            }
            return product;
        }
    }
}