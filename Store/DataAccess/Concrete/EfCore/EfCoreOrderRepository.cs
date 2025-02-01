using DataAccess.Abstract;
using DataAccess.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Repositories.EntityFramework
{
    public class EfCoreOrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(RepositoryContext context) : base(context)
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