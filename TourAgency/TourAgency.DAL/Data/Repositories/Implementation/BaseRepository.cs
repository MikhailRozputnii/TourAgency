using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbContext.Set<TEntity>().Where(predicate).Count();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(int id) =>
            _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(t => t.Id == id);

        public virtual bool IsExistAsync(int id) =>
            _dbContext.Set<TEntity>().Any(x => x.Id == id);

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}