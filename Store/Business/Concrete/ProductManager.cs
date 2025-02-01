using AutoMapper;
using Business.Abstract;
using DataAccess.RepositoryManager;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.CreateOneProduct(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            var entity = _manager.Product.GetOneProduct(id, false);
            CheckIfEntityExists(entity);
            _manager.Product.DeleteOneProduct(entity!);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var entity = _manager.Product.GetOneProduct(id, trackChanges);
            CheckIfEntityExists(entity);
            return entity;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity  = _manager.Product.GetOneProduct(productDto.ProductId, true);
            // CheckIfEntityExists(entity);
            // entity!.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;

            // yeni referans gelecegi icin izleme olmaz.
            var entity = _mapper.Map<Product>(productDto);

            // bu yuzden update etmeliyiz.
            _manager.Product.UpdateOneProduct(entity);
            _manager.Save();
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