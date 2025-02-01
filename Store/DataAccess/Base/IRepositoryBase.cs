using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Base
{
    public interface IRepositoryBase<T> where T: class, IEntity, new()
    {
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}