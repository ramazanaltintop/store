using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IQueryableRepository<Category>
    {
        IQueryable<Category> GetAllCategories(bool trackChanges);
    }
}