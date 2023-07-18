using Mono.SharedLibrary;

namespace Mono.Service.Services.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAllVehicleModels();
        Task<VehicleModelViewModel> GetVehicleModel(int id);
        void CreateVehicleModel(VehicleModel vehicleModel);
        void UpdateVehicleModel(VehicleModel vehicleModel);
        void DeleteVehicleModel(int id);
    }
}
