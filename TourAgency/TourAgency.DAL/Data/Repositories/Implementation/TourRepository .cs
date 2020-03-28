using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourAgency.DAL.Data.Entities;
using TourAgency.DAL.Extensions;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Tour> GetByExpression(Expression<Func<Tour, bool>> predicate, int pageNumber, int pageSize, string sortProperty = "Id", bool isAsc = true)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            var query = _dbContext.Tours
                .Include(i => i.Images)
                .Include(t => t.TourLocations).ThenInclude(tl => tl.Location)
                .Where(predicate)
                .Paging(pageNumber, pageSize);

            query = isAsc ? query.OrderBy(sortProperty) : query.OrderByDescending(sortProperty);
            return query;
        }

        public override Tour GetById(int id)
        {
            return _dbContext.Tours
                .Include(ti => ti.Images)
                .Include(t => t.TourLocations).ThenInclude(tl => tl.Location)
                .AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Tour entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.ModifiedAt = DateTime.UtcNow;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}