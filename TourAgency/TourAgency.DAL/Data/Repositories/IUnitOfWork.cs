using System;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<OrderStatus> OrderStatusRepository { get; }
        IRepository<Location> LocationRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<Tour> TourRepository { get; }

        void Save();
    }
}