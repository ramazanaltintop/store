using Business.Abstract;
using Core.Entities;
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

        public void CreateOneProduct(Product product)
        {
            _dalCoordinator.Product.CreateOneProduct(product);
            _dalCoordinator.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var entity = _dalCoordinator.Product.GetOneProduct(id, false);
            CheckIfEntityExists(entity);
            _dalCoordinator.Product.DeleteOneProduct(entity!);
            _dalCoordinator.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _dalCoordinator.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var entity = _dalCoordinator.Product.GetOneProduct(id, trackChanges);
            CheckIfEntityExists(entity);
            return entity;
        }

        public void UpdateOneProduct(Product product)
        {
            var entity  = _dalCoordinator.Product.GetOneProduct(product.ProductId, true);
            CheckIfEntityExists(entity);
            entity!.ProductName = product.ProductName;
            entity.Price = product.Price;
            _dalCoordinator.Save();
        }

        private void CheckIfEntityExists(IEntity? entity)
        {
            if (entity is null)
            {
                throw new Exception("Product not found!");
            }
        }
    }
}