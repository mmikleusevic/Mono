using Mono.SharedLibrary;
using System.Net.NetworkInformation;

namespace Mono.MVC.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAll();
        Task<List<VehicleModelViewModel>> Paging(Paging paging);
        Task<VehicleModelViewModel> GetById(int id);
        Task Create(VehicleModelViewModel vehicleModelViewModel);
        Task Update(VehicleModelViewModel vehicleModelViewModel, int id);
        Task Delete(int id);
    }
}
