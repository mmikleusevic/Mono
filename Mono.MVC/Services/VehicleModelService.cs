using Mono.MVC.Interfaces;
using Mono.SharedLibrary;
using System.Text.Json;

namespace Mono.MVC.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly HttpClient _httpClient;

        public VehicleModelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleModelViewModel>> GetAll()
        {
            List<VehicleModelViewModel> result = new List<VehicleModelViewModel>();
            HttpResponseMessage? response = await _httpClient.GetAsync("api/VehicleModel");
            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleModelViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task<VehicleModelViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleModelViewModel>> Paging(Paging paging)
        {
            throw new NotImplementedException();
        }

        public async Task Update(VehicleModel vehicleModel)
        {
            throw new NotImplementedException();
        }
    }
}
