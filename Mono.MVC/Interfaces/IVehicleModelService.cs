using Mono.SharedLibrary;

namespace Mono.MVC.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAll();
        Task<List<VehicleModelViewModel>> Paging(OrderAndSort paging);
        Task<VehicleModelViewModel> GetById(int id);
        Task Create(VehicleModelViewModel vehicleModelViewModel);
        Task Update(VehicleModelViewModel vehicleModelViewModel, int id);
        Task Delete(int id);
    }
}
