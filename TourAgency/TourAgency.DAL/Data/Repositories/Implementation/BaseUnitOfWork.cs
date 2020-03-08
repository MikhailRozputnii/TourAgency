using System;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories.Implementation
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private OrderStatusRepository _orderStatusRepository;
        private LocationRepository _locationRepository;
        private OrderRepository _orderRepository;
        private ImageRepository _imageRepository;
        private TourRepository _tourRepository;

        public BaseUnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<OrderStatus> OrderStatusRepository =>
            _orderStatusRepository ??= new OrderStatusRepository(_dbContext);

        public IRepository<Location> LocationRepository =>
            _locationRepository ??= new LocationRepository(_dbContext);

        public IRepository<Order> OrderRepository =>
            _orderRepository ??= new OrderRepository(_dbContext);

        public IRepository<Image> ImageRepository =>
            _imageRepository ??= new ImageRepository(_dbContext);

        public IRepository<Tour> TourRepository =>
            _tourRepository ??= new TourRepository(_dbContext);

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