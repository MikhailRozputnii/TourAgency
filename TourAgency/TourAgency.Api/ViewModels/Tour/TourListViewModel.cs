using System.Collections.Generic;

namespace TourAgency.Api.ViewModels.Tour
{
    public class TourListViewModel
    {
        public IEnumerable<TourViewModel> TourViewModels { get; set; }
        public PagingInfo Paginginfo { get; set; }
    }
}