using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implement
{
    public class LocationRepository : BaseRepository<Location>
    {
        public LocationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}