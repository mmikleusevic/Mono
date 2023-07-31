using AutoMapper;
using Mono.SharedLibrary;

namespace Mono.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //VehicleMake - VehicleMakeViewModel
            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ForMember(x => x.VehicleModelViewModels,
                    opts => opts.MapFrom(a => a.VehicleModels))
                .ReverseMap();

            //VehicleModel - VehicleModelViewModel
            CreateMap<VehicleModel, VehicleModelViewModel>()
                .ForMember(x => x.VehicleMakeViewModel,
                    opts => opts.MapFrom(a => a.VehicleMake))
                .ReverseMap();
        }
    }
}
