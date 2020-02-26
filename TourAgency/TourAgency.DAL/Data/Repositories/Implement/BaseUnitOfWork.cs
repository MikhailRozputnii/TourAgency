using System;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implement
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private readonly OrderStatusRepository _orderStatusRepository;
        private readonly LocationRepository _locationRepository;
        private readonly OrderRepository _orderRepository;
        private readonly ImageRepository _imageRepository;
        private readonly TourRepository _tourRepository;

        public BaseUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<OrderStatus> OrderStatusRepository =>
            _orderStatusRepository ?? new OrderStatusRepository(_dbContext);

        public IRepository<Location> LocationRepository =>
            _locationRepository ?? new LocationRepository(_dbContext);

        public IRepository<Order> OrderRepository =>
            _orderRepository ?? new OrderRepository(_dbContext);

        public IRepository<Image> ImageRepository =>
            _imageRepository ?? new ImageRepository(_dbContext);

        public IRepository<Tour> TourRepository =>
            _tourRepository ?? new TourRepository(_dbContext);

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}