using System;

namespace TourAgency.BLL.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int CustomerId { get; set; }
        public UserDto Customer { get; set; }

        public int TourId { get; set; }
        public TourDto Tour { get; set; }

        public int? OrderStatusId { get; set; }

        public OrderStatusDto OrderStatus { get; set; }
        public bool IsDeleted { get; set; }
    }
}