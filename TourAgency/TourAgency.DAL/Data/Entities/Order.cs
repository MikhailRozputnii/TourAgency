using System;

namespace TourAgency.DAL.Data.Entities
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int? CustomerId { get; set; }
        public User Customer { get; set; }

        public int? TourId { get; set; }
        public Tour Tour { get; set; }

        public int? OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}