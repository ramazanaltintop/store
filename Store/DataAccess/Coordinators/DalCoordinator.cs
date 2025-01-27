using DataAccess.Abstract;
using DataAccess.Coordinators;

namespace DataAccess.Concrete.EntityFramework
{
    public class DalCoordinator : IDalCoordinator
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;

        public DalCoordinator(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public IProductDal Product => _productDal;

        public ICategoryDal Category => _categoryDal;
    }
}