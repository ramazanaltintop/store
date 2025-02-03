using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        IEnumerable<Product> GetShowcaseProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}