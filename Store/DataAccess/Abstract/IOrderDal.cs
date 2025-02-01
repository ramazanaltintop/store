using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IQueryableRepository<Order>
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProgress { get; }
    }
}