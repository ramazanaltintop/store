using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories(bool trackChanges);
    }
}