using Microsoft.AspNetCore.Identity;
using System;

namespace TourAgency.DAL.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }

        public string ImageUrl { get; set; }
    }
}