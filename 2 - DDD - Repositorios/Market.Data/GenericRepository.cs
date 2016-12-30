using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Market.Data
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        //TODO 01 : Se agrega GenericRepository
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

        public IQueryable<TEntity> AllQuery()
        {
            return DbSet.AsNoTracking();
        }
        public TEntity FindByKey(int id)
        {
            return DbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = FindByKey(id);
            DbSet.Remove(entity);
        }
    }
}