using DataAccess.Base;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> GetAllCategories(bool trackChanges);
    }
}