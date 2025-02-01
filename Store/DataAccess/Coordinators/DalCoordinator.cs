using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Coordinators;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class DalCoordinator : IDalCoordinator
    {
        private readonly DbContext _context;
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;

        public DalCoordinator(RepositoryContext context, IProductDal productDal, ICategoryDal categoryDal)
        {
            _context = context;
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public IProductDal Product => _productDal;

        public ICategoryDal Category => _categoryDal;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}