using DataAccess.Abstract;
using DataAccess.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EntityFramework
{
    public class EfCoreOrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public EfCoreOrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public int NumberOfInProgress => _context.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id), true);
            if (order is null)
                throw new Exception("Order not found!");
            order.Shipped = true;
        }

        public Order? GetOneOrder(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id), false);
            if (order is null)
                throw new Exception("Order not found!");
            return order;
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}