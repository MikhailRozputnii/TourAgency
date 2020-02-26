using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implement
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}