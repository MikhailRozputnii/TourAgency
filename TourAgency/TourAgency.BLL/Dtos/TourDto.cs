using System;
using System.Collections.Generic;

namespace TourAgency.BLL.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<TourLocationDto> TourLocations { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}