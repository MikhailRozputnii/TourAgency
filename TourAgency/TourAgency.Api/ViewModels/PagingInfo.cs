using System;

namespace TourAgency.Api.ViewModels
{
    public class PagingInfo
    {
        public static int PageSize { get { return 3; } }

        public int Totalitems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)Totalitems / ItemsPerPage);
    }
}