using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implement
{
    public class OrderStatusRepository : BaseRepository<OrderStatus>
    {
        public OrderStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}