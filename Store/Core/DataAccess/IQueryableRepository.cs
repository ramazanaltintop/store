using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IQueryableRepository<T> where T: class, IEntity, new()
    {
        IQueryable<T> GetAll(bool trackChanges);
        T? Get(Expression<Func<T, bool>> expression, bool trackChanges);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}