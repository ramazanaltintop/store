using DataAccess.Abstract;
using DataAccess.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Repositories.EntityFramework
{
    public class EfCoreCategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Category> GetAllCategories(bool trackChanges) => FindAll(trackChanges);
    }
}