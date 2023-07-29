using Mono.SharedLibrary;

namespace Mono.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAllVehicleModels();
        Task<List<VehicleModelViewModel>> PagingVehicleModels(Paging paging);
        Task<VehicleModelViewModel> GetVehicleModel(int id);
        Task CreateVehicleModel(VehicleModelViewModel vehicleModelViewModel);
        Task UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel);
        Task DeleteVehicleModel(int id);
    }
}
