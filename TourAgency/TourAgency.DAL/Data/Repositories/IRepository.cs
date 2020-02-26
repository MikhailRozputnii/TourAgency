using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TourAgency.DAL.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///  Get collection of entities by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Entity Collection</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Create list of entities
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity">Entity type</param>
        /// <returns>Entity</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        ///  Update current entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        ///  Check for entity by id is exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Exists boolean indication</returns>
        bool IsExistAsync(int id);

        /// <summary>
        ///  Get count of elements in an entity collection by expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Count of collection</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///  Delete entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Delete(TEntity entity);
    }
}