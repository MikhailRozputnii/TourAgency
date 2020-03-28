namespace TourAgency.BLL.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public int TourId { get; set; }
        public TourDto Tour { get; set; }
    }
}