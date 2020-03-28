using System.Collections.Generic;

namespace TourAgency.BLL.Dtos
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<TourLocationDto> TourLocations { get; set; }
    }
}