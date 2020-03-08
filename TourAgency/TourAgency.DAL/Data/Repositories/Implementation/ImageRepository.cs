using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class ImageRepository : BaseRepository<Image>
    {
        public ImageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}