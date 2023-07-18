using Mono.Service.Services.Interfaces;
using Mono.SharedLibrary;

namespace Mono.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        public void CreateVehicleModel(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleModelViewModel>> GetAllVehicleModels()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModelViewModel> GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicleModel(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
