using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;
using Mono.SharedLibrary;
using System.Net;
using System.Text;
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

        public async Task Create(VehicleModelViewModel vehicleModelViewModel)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleModelViewModel), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/VehicleModel", httpContent);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/VehicleModel/{id}");           
        }

        public async Task<List<VehicleModelViewModel>> GetAll()
        {
            List<VehicleModelViewModel> result = new List<VehicleModelViewModel>();
            HttpResponseMessage? response = await _httpClient.GetAsync("api/VehicleModel");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleModelViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task<VehicleModelViewModel> GetById(int id)
        {
            VehicleModelViewModel result = new VehicleModelViewModel();
            HttpResponseMessage? response = await _httpClient.GetAsync($"api/VehicleModel/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<VehicleModelViewModel>(responseStream);
            }

            return result!;
        }

        public async Task<List<VehicleModelViewModel>> Paging(Paging paging)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(paging), Encoding.UTF8, "application/json");

            List<VehicleModelViewModel> result = new List<VehicleModelViewModel>();

            HttpResponseMessage? response = await _httpClient.PutAsync($"api/VehicleModel/paged", httpContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream? responseStream = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<List<VehicleModelViewModel>>(responseStream);
            }

            return result!;
        }

        public async Task Update(VehicleModelViewModel vehicleModelViewModel, int id)
        {
            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(vehicleModelViewModel), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/VehicleModel/{id}", httpContent);
        }
    }
}
