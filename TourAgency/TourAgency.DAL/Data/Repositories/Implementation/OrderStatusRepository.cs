using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class OrderStatusRepository : BaseRepository<OrderStatus>
    {
        public OrderStatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}