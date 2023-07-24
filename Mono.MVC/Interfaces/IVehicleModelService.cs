using Mono.SharedLibrary;
using System.Net.NetworkInformation;

namespace Mono.MVC.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAll();
        Task<List<VehicleModelViewModel>> Paging(Paging paging);
        Task<VehicleModelViewModel> GetById(int id);
        Task Create(VehicleModel vehicleModel);
        Task Update(VehicleModel vehicleModel);
        Task Delete(int id);
    }
}
