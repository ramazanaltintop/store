using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T>
    where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return trackChanges
                ? _dbSet
                : _dbSet.AsNoTracking();
        }

        public T? Get(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? _dbSet.Where(expression).SingleOrDefault()
                : _dbSet.Where(expression).AsNoTracking().SingleOrDefault();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}