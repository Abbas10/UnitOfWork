using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Test.ORM
{
    public interface IRepository<TEntity,TDestination> where TEntity: class 
    {
        TDestination Get(int id);
        IEnumerable<TDestination> GetAll();
        IEnumerable<TDestination> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TDestination SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
