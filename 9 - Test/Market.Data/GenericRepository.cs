using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Market.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> AllInclude
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<TEntity> FindByInclude
          (Expression<Func<TEntity, bool>> predicate,
          params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<TEntity> GetAllIncluding
        (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> results = DbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        public TEntity FindByKey(int id)
        {
            Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
            return DbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = FindByKey(id);
            DbSet.Remove(entity);
            Context.SaveChanges();
        }
    }
}