using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfQueryableRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(ProductDbContext context) : base(context)
        {
        }

        public IQueryable<Category> GetAllCategories(bool trackChanges) => FindAll(trackChanges);
    }
}