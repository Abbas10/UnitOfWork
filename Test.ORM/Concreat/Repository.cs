using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Test.ORM
{
    public class Repository<TEntity, TDestination> : IRepository<TEntity, TDestination> where TEntity: class 
    {
        protected readonly DbContext Context;
        protected readonly IMapper Mapper;
        public Repository(){}

        public Repository(DbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public TDestination Get(int id)
        {
            // Here we are working with a DbContext, not TestDbContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return  Mapper.Map<TEntity, TDestination>(Context.Set<TEntity>().Find(id));
        }

        public IEnumerable<TDestination> GetAll()
        {
            return Mapper.Map<IList<TEntity>,IList<TDestination>>(Context.Set<TEntity>().ToList());
        }

        public IEnumerable<TDestination> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ProjectTo<TDestination>();
        }

        public TDestination SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Mapper.Map<TEntity,TDestination>(Context.Set<TEntity>().SingleOrDefault(predicate));
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
