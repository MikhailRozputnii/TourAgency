using AutoMapper;
using System.Linq;
using TourAgency.Api.ViewModels.Tour;
using TourAgency.BLL.Dtos;

namespace TourAgency.Api.Configuration.Mapper
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<TourDto, TourViewModel>()
                .ForMember(tvm => tvm.LocationsViewModel, tdto => tdto.MapFrom(tl => tl.TourLocations.Select(l => l.Location).ToList())).ReverseMap();
            CreateMap<TourLocationDto, LocationViewModel>().ReverseMap();
            CreateMap<ImageDto, ImageViewModel>().ReverseMap();
            CreateMap<LocationDto, LocationViewModel>().ReverseMap();
        }
    }
}