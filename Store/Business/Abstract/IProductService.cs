using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        Product GetProductById(int id, bool trackChanges);
    }
}