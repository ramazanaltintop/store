using Business.Abstract;

namespace Business.Coordinators
{
    public interface IServiceCoordinator
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
    }
}