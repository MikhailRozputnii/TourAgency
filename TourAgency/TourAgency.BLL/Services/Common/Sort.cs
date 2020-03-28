using System;
using System.Linq;
using TourAgency.BLL.Exceptions;

namespace TourAgency.BLL.Services.Common
{
    public static class Sort
    {
        public static (string property, bool isAsc) GetSortOrder<T>(string propertyName, SortOrder sortOrder)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var propName = typeof(T).GetProperties().FirstOrDefault(t => t.Name.Contains(propertyName)).Name;
            if (propName == null)
                throw new PropertyNotFoundException(nameof(propertyName));

            switch (sortOrder)
            {
                case SortOrder.Asc:
                    return (propName, true);

                case SortOrder.Desc:
                    return (propName, false);

                default:
                    return ("Id", true);
            }
        }
    }

    public enum SortOrder
    {
        Asc,
        Desc,
    }
}