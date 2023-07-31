using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;
using Mono.SharedLibrary;
using X.PagedList;

namespace Mono.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly ILogger<VehicleModelController> _logger;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleModelController(ILogger<VehicleModelController> logger,
            IVehicleModelService vehicleModelService,
            IVehicleMakeService vehicleMakeService)
        {
            _logger = logger;
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
        }
        public async Task<IActionResult> Index(OrderAndSort paging, int? page)
        {
            _logger.LogInformation("Index(OrderAndSort paging) started");

            int pageNumber = page ?? 1;

            List<VehicleModelViewModel> model = await _vehicleModelService.Paging(paging);

            ViewData["Sort"] = paging;

            return View(model.ToPagedList(pageNumber, 10));
        }

        public async Task<IActionResult> CreateVehicleModel(VehicleModelViewModel vehicleModelViewModel)
        {
            _logger.LogInformation("CreateVehicleModel(VehicleModel vehicleModel) started");

            await _vehicleModelService.Create(vehicleModelViewModel);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            _logger.LogInformation("DeleteVehicleModel(int id) started");

            await _vehicleModelService.Delete(id);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> UpdateVehicleModel(VehicleModelViewModel vehicleModelViewModel, int id)
        {
            _logger.LogInformation("UpdateVehicleModel(VehicleModelViewModel vehicleModel, int id) started");

            await _vehicleModelService.Update(vehicleModelViewModel, id);

            return Redirect("/VehicleModel");
        }

        public async Task<IActionResult> DetailsVehicleModel(int id)
        {
            _logger.LogInformation("DetailsVehicleModel(int id) started");

            VehicleModelViewModel model = await _vehicleModelService.GetById(id);

            ViewData["makes"] = await _vehicleMakeService.GetAll();

            return View(model);
        }

        public async Task<List<VehicleModelViewModel>> GetAll()
        {
            _logger.LogInformation("GetAll() started");

            List<VehicleModelViewModel> model = await _vehicleModelService.GetAll();

            return model;
        }

        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            _logger.LogInformation("DeleteConfirmation(int id) started");

            ViewBag.ItemId = id;

            return await Task.FromResult(View());
        }
    }
}
