using Mono.SharedLibrary;

namespace Mono.MVC.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<List<VehicleMakeViewModel>> GetAll();
        Task<List<VehicleMakeViewModel>> Paging(OrderAndSort paging);
        Task<VehicleMakeViewModel> GetById(int id);
        Task Create(VehicleMakeViewModel vehicleMakeViewModel);
        Task Update(VehicleMakeViewModel vehicleMakeViewModel, int id);
        Task Delete(int id);
    }
}
