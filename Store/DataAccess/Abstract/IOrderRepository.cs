using DataAccess.Base;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complete(int id);
        void SaveOrder(Order order);
        int NumberOfInProgress { get; }
    }
}