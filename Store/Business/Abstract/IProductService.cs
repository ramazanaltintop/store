using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
    }
}