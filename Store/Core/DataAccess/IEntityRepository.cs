using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        T? GetByCondition(Expression<Func<T, bool>> filter);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}