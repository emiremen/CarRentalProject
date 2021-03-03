using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var addedEntity = dBContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dBContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var deletedEntity = dBContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dBContext = new TContext())
            {
                return filter == null ? dBContext.Set<TEntity>().ToList() : dBContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext dBContext = new TContext())
            {
                return dBContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var updatedContext = dBContext.Entry(entity);
                updatedContext.State = EntityState.Modified;
                dBContext.SaveChanges();
            }
        }
    }
}
