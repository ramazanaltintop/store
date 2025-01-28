using DataAccess.Abstract;

namespace DataAccess.Coordinators
{
    public interface IDalCoordinator
    {
        IProductDal Product { get; }
        ICategoryDal Category { get; }
        void Save();
    }
}