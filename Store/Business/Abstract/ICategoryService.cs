using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
    }
}