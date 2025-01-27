using Business.Abstract;

namespace Business.Coordinators
{
    public class ServiceCoordinator : IServiceCoordinator
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ServiceCoordinator(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;
    }
}