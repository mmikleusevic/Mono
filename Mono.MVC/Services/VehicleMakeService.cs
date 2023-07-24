using Mono.MVC.Interfaces;
using Mono.SharedLibrary;

namespace Mono.MVC.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly HttpClient _httpClient;

        public VehicleMakeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleMakeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleMakeViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleMakeViewModel>> Paging(Paging paging)
        {
            throw new NotImplementedException();
        }

        public async Task Update(VehicleMake vehicleMake)
        {
            throw new NotImplementedException();
        }
    }
}
