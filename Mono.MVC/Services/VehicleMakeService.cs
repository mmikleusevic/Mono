using Mono.MVC.Interfaces;
using Mono.SharedLibrary;
using System.Net;
using System.Net.Http;
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

        public async Task Create(VehicleMake vehicleMake)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleMake), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/VehicleMake", httpContent);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/VehicleMake/{id}");
        }

        public async Task<List<VehicleMakeViewModel>> GetAll()
        {
            List<VehicleMakeViewModel> result = new List<VehicleMakeViewModel>();
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
            VehicleMakeViewModel result = new VehicleMakeViewModel();
            HttpResponseMessage? response = await _httpClient.GetAsync($"api/VehicleMake/{id}");
            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<VehicleMakeViewModel>(responseStream);
            }

            return result!;
        }

        public async Task<List<VehicleMakeViewModel>> Paging(Paging paging)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(paging), Encoding.UTF8, "application/json");

            List<VehicleMakeViewModel> result = new List<VehicleMakeViewModel>();

            HttpResponseMessage? response = await _httpClient.PutAsync($"api/VehicleMake/paged", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleMakeViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task Update(VehicleMake vehicleMake, int id)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleMake), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/VehicleMake/{id}", httpContent);
        }
    }
}
