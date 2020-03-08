using System;
using System.Collections.Generic;
using System.Text;

namespace TourAgency.DAL.Constants
{
    public class Constants
    {
        public static class Roles
        {
            public const string Admin = "Admin";
            public const string Customer = "Customer";
        }

        public enum OrderStatus
        {
            InProgress = 1,
            Completed
        }

        public enum Role
        {
            Admin = 1,
            Customer
        }
    }
}