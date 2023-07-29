using Mono.SharedLibrary;

namespace Mono.Service.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMakeViewModel>> GetAllVehicleMakes();
        Task<List<VehicleMakeViewModel>> PagingVehicleMakes(Paging paging);
        Task<VehicleMakeViewModel> GetVehicleMake(int id);
        Task CreateVehicleMake(VehicleMakeViewModel vehicleMake);
        Task UpdateVehicleMake(VehicleMakeViewModel vehicleMake);
        Task DeleteVehicleMake(int id);
    }
}
