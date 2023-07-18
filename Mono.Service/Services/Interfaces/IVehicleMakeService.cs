using Mono.SharedLibrary;

namespace Mono.Service.Services.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMakeViewModel>> GetAllVehicleMakes();
        Task<VehicleMakeViewModel> GetVehicleMake(int id);
        Task CreateVehicleMake(VehicleMake vehicleMake);
        Task UpdateVehicleMake(VehicleMake vehicleMake);
        Task DeleteVehicleMake(int id);
    }
}
