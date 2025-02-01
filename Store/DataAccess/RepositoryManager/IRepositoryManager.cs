using DataAccess.Abstract;

namespace DataAccess.RepositoryManager
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}