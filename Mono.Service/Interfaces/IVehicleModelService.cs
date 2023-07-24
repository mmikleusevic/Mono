﻿using Mono.SharedLibrary;

namespace Mono.Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<List<VehicleModelViewModel>> GetAllVehicleModels();
        Task<List<VehicleModelViewModel>> PagingVehicleModels(Paging paging);
        Task<VehicleModelViewModel> GetVehicleModel(int id);
        Task CreateVehicleModel(VehicleModel vehicleModel);
        Task UpdateVehicleModel(VehicleModel vehicleModel);
        Task DeleteVehicleModel(int id);
    }
}