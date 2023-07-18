using Mono.SharedLibrary;

namespace Mono.Service.Services.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAllVehicleModels();
        Task<VehicleModelViewModel> GetVehicleModel(int id);
        Task CreateVehicleModel(VehicleModel vehicleModel);
        Task UpdateVehicleModel(VehicleModel vehicleModel);
        Task DeleteVehicleModel(int id);
    }
}
