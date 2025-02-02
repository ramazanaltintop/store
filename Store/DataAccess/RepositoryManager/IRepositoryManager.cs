using DataAccess.Abstract;

namespace DataAccess.RepositoryManager
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        void Save();
    }
}