namespace TourAgency.DAL.Data.Entities
{
    public class TourLocation
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}