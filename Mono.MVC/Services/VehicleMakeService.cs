using Mono.MVC.Interfaces;
using Mono.SharedLibrary;
using System.Text;
using System.Text.Json;

namespace Mono.MVC.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly HttpClient _httpClient;

        public VehicleMakeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(VehicleMakeViewModel vehicleMakeViewModel)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleMakeViewModel), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/VehicleMake", httpContent);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/VehicleMake/{id}");
        }

        public async Task<List<VehicleMakeViewModel>> GetAll()
        {
            List<VehicleMakeViewModel>? result = null;
            HttpResponseMessage? response = await _httpClient.GetAsync("api/VehicleMake");
            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleMakeViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task<VehicleMakeViewModel> GetById(int id)
        {
            VehicleMakeViewModel? result = null;
            if (id == 0)
            {
                result = new VehicleMakeViewModel();
            }
            HttpResponseMessage? response = await _httpClient.GetAsync($"api/VehicleMake/{id}");
            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<VehicleMakeViewModel>(responseStream);
            }

            return result!;
        }

        public async Task<List<VehicleMakeViewModel>> Paging(OrderAndSort paging)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(paging), Encoding.UTF8, "application/json");

            List<VehicleMakeViewModel>? result = null;

            HttpResponseMessage? response = await _httpClient.PostAsync($"api/VehicleMake/paged", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleMakeViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task Update(VehicleMakeViewModel vehicleMakeViewModel, int id)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleMakeViewModel), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/VehicleMake/{id}", httpContent);
        }
    }
}
