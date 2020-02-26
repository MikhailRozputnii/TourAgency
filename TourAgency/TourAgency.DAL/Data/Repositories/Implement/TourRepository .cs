using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implement
{
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}