using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfQueryableRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(ProductDbContext context) : base(context)
        {
        }
    }
}