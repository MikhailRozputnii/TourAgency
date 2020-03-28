using System.Collections.Generic;

namespace TourAgency.Api.ViewModels.Tour
{
    public class TourViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<LocationViewModel> LocationsViewModel { get; set; }
        public IEnumerable<ImageViewModel> ImagesViewModel { get; set; }
    }
}