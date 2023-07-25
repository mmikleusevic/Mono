using Mono.SharedLibrary;
using System.Net.NetworkInformation;

namespace Mono.MVC.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMakeViewModel>> GetAll();
        Task<List<VehicleMakeViewModel>> Paging(Paging paging);
        Task<VehicleMakeViewModel> GetById(int id);
        Task Create(VehicleMake vehicleMake);
        Task Update(VehicleMake vehicleMake, int id);
        Task Delete(int id);
    }
}
