using Mono.SharedLibrary;

namespace Mono.Service.Services.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMakeViewModel>> GetAllVehicleMakes();
        Task<VehicleMakeViewModel> GetVehicleMake(int id);
        void CreateVehicleMake(VehicleMake vehicleMake);
        void UpdateVehicleMake(VehicleMake vehicleMake);
        void DeleteVehicleMake(int id);
    }
}
