using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency.DAL.Data.Entities
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}