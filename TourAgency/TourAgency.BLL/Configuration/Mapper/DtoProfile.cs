using AutoMapper;
using System.Linq;
using TourAgency.BLL.Dtos;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.BLL.Configuration.Mapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<TourLocation, TourLocationDto>().ReverseMap();
        }
    }
}