namespace TourAgency.BLL.Dtos
{
    public class TourLocationDto
    {
        public int TourId { get; set; }
        public TourDto Tour { get; set; }

        public int LocationId { get; set; }
        public LocationDto Location { get; set; }
    }
}