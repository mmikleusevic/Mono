using AutoMapper;
using Mono.SharedLibrary;

namespace Mono.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Map smth...

            //VehicleMake - VehicleMakeViewModel
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                    .ReverseMap();

            //VehicleModel - VehicleModelViewModel
            CreateMap<VehicleModel, VehicleModelViewModel>()
                    .ReverseMap();
        }
    }
}
