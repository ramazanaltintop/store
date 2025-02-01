using AutoMapper;
using Business.Abstract;
using DataAccess.Coordinators;
using Entities.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IDalCoordinator _dalCoordinator;
        private readonly IMapper _mapper;

        public ProductManager(IDalCoordinator dalCoordinator, IMapper mapper)
        {
            _dalCoordinator = dalCoordinator;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
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

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = _dalCoordinator.Product.GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity  = _dalCoordinator.Product.GetOneProduct(productDto.ProductId, true);
            // CheckIfEntityExists(entity);
            // entity!.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;

            // yeni referans gelecegi icin izleme olmaz.
            var entity = _mapper.Map<Product>(productDto);

            // bu yuzden update etmeliyiz.
            _dalCoordinator.Product.UpdateOneProduct(entity);
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