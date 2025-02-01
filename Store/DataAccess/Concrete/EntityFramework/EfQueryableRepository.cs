using System.Linq.Expressions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public abstract class EfQueryableRepository<T> : IQueryableRepository<T>
    where T : class, IEntity, new()
    {
        protected readonly ProductDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected EfQueryableRepository(ProductDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges
                ? _dbSet
                : _dbSet.AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _dbSet.Where(expression).SingleOrDefault()
                : _dbSet.Where(expression).AsNoTracking().SingleOrDefault();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}