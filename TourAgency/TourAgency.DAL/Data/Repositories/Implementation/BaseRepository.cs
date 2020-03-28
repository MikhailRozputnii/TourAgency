using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourAgency.DAL.Data.Entities;
using TourAgency.DAL.Extensions;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbContext.Set<TEntity>().Where(predicate).Count();
        }

        public virtual IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize, string sortProperty = "Id", bool isAsc = true)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var query = _dbContext.Set<TEntity>().Where(predicate).Paging(pageNumber, pageSize).Paging(pageNumber, pageSize);
            query = isAsc ? query.OrderBy(sortProperty) : query.OrderByDescending(sortProperty);
            return query;
        }

        public virtual IEnumerable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity GetById(int id) =>
            _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(t => t.Id == id);

        public virtual bool IsExist(int id) =>
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