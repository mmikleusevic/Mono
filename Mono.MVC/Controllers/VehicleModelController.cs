using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;
using Mono.MVC.Services;
using Mono.SharedLibrary;

namespace Mono.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly ILogger<VehicleModelController> _logger;
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(ILogger<VehicleModelController> logger,
            IVehicleModelService vehicleModelService) 
        {
            _logger = logger;
            _vehicleModelService = vehicleModelService;
        }
        public async Task<List<VehicleModelViewModel>> Index()
        {
            return await _vehicleModelService.GetAll();
        }
    }
}
