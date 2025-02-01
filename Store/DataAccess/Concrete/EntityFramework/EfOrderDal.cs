using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfQueryableRepository<Order>, IOrderDal
    {
        public EfOrderDal(ProductDbContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => throw new NotImplementedException();

        public int NumberOfInProgress => throw new NotImplementedException();

        public void Complete(int id)
        {
            throw new NotImplementedException();
        }

        public Order? GetOneOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}