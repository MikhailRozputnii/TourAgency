using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}