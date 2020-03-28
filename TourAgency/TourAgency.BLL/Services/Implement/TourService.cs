using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using TourAgency.BLL.Dtos;
using TourAgency.BLL.Exceptions;
using TourAgency.BLL.Services.Common;
using TourAgency.DAL.Data.Entities;
using TourAgency.DAL.Data.Repositories;

namespace TourAgency.BLL.Services.Implement
{
    public class TourService : IEntityService<TourDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(TourDto tourDto)
        {
            if (tourDto == null)
                throw new ArgumentNullException(nameof(tourDto));
            var tour = _mapper.Map<Tour>(tourDto);
            _unitOfWork.TourRepository.Add(tour);
            _unitOfWork.Save();
        }

        public void AddRange(IEnumerable<TourDto> tourDtos)
        {
            if (tourDtos == null)
                throw new ArgumentNullException(nameof(tourDtos));
            var tours = _mapper.Map<IEnumerable<Tour>>(tourDtos);
            _unitOfWork.TourRepository.AddRange(tours);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var tour = _unitOfWork.TourRepository.GetById(id);
            if (tour == null)
                throw new EntityNotFoundException(nameof(tour));
            _unitOfWork.TourRepository.Delete(tour);
            _unitOfWork.Save();
        }

        public (IEnumerable<TourDto> items, int total) Find(int pageNumber, int pageSize, string propertyName = "IdAsc", string search = null)
        {
            bool isAsc;
            int total;
            Expression<Func<Tour, bool>> predicate = t => t.IsDeleted != true;

            if (!String.IsNullOrEmpty(search))
            {
                search = search.Trim();
                predicate = t => t.IsDeleted != true && t.Description.Contains(search) || t.Name.Contains(search);
            }

            total = _unitOfWork.TourRepository.Count(predicate);
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageNumber > total)
                pageNumber = total;

            (propertyName, isAsc) = propertyName.Contains("Asc") ?
                Sort.GetSortOrder<Tour>(propertyName, SortOrder.Asc) :
                Sort.GetSortOrder<Tour>(propertyName, SortOrder.Desc);

            var tours = _unitOfWork.TourRepository.GetByExpression(predicate, pageNumber, pageSize, propertyName, isAsc);
            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);
            return (toursDto, total);
        }

        public TourDto GetById(int id)
        {
            var tour = _unitOfWork.TourRepository.GetById(id);
            if (tour == null)
                throw new EntityNotFoundException(nameof(tour));
            var tourDto = _mapper.Map<TourDto>(tour);
            return tourDto;
        }

        public void Update(TourDto tourDto)
        {
            if (tourDto == null)
                throw new ArgumentNullException(nameof(tourDto));
            bool isEntityExists = _unitOfWork.TourRepository.IsExist(tourDto.Id);
            if (!isEntityExists)
                throw new EntityNotFoundException(nameof(tourDto));
            var tour = _mapper.Map<Tour>(tourDto);
            _unitOfWork.TourRepository.Update(tour);
            _unitOfWork.Save();
        }
    }
}