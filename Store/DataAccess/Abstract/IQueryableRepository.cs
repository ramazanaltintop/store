using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface IQueryableRepository<T> where T: class, IEntity, new()
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}