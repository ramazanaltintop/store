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

        public List<Product> GetAllProducts()
        {
            return _dalCoordinator.Product.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _dalCoordinator.Product.Get(p => p.ProductId.Equals(id));
        }
    }
}