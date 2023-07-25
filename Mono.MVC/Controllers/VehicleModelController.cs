using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;
using Mono.MVC.Services;
using Mono.SharedLibrary;
using System.Collections.Generic;

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
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index() started");

            List<VehicleModelViewModel> model = await _vehicleModelService.GetAll();

            return View(model);
        }

        public async Task<IActionResult> CreateVehicleModel(VehicleModel vehicleModel)
        {
            _logger.LogInformation("CreateVehicleModel(VehicleModel vehicleModel) started");

            await _vehicleModelService.Create(vehicleModel);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            _logger.LogInformation("DeleteVehicleModel(int id) started");

            await _vehicleModelService.Delete(id);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> UpdateVehicleModel(VehicleModel vehicleModel, int id)
        {
            _logger.LogInformation("UpdateVehicleModel(VehicleModel vehicleModel, int id) started");

            await _vehicleModelService.Update(vehicleModel, id);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> DetailsVehicleModel(int id)
        {
            _logger.LogInformation("DetailsVehicleModel(int id) started");

            VehicleModelViewModel model = await _vehicleModelService.GetById(id);

            return View(model);
        }

        public async Task<IActionResult> PagingVehicleModel(Paging paging)
        {
            _logger.LogInformation("PagingVehicleModel(Paging paging) started");

            List<VehicleModelViewModel> model = await _vehicleModelService.Paging(paging);

            return View(model);
        }
    }
}
