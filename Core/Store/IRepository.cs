using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Store
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void AddOrUpdate(TEntity item);
        void AddRange(IEnumerable<TEntity> items);

        void Remove(TEntity item);
        void RemoveRange(IEnumerable<TEntity> items);

    }
}
