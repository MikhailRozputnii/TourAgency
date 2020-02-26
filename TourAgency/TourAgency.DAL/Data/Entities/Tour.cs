using System;
using System.Collections.Generic;

namespace TourAgency.DAL.Data.Entities
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Image> Images { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}