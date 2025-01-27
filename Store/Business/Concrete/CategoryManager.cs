using Business.Abstract;
using DataAccess.Coordinators;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private IDalCoordinator _dalCoordinator;

        public CategoryManager(IDalCoordinator dalCoordinator)
        {
            _dalCoordinator = dalCoordinator;
        }

        public List<Category> GetAllCategories()
        {
            return _dalCoordinator.Category.GetAll();
        }
    }
}