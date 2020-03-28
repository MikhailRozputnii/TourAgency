using System.Collections.Generic;

namespace TourAgency.BLL.Services
{
    public interface IEntityService<T> where T : class
    {
        void Add(T dto);

        (IEnumerable<T> items, int total) Find(int pageNumber, int pageSize, string propertyName = "Id", string search = null);

        T GetById(int id);

        void AddRange(IEnumerable<T> dtos);

        void Update(T dto);

        void Delete(int id);
    }
}