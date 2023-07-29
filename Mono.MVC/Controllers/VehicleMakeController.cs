using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;
using Mono.SharedLibrary;

namespace Mono.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly ILogger<VehicleMakeController> _logger;
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(ILogger<VehicleMakeController> logger,
            IVehicleMakeService vehicleMakeService)
        {
            _logger = logger;
            _vehicleMakeService = vehicleMakeService;
        }
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index() started");

            List<VehicleMakeViewModel> model = await _vehicleMakeService.GetAll();

            return View(model);
        }

        public async Task<IActionResult> CreateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel)
        {
            _logger.LogInformation("CreateVehicleMake(VehicleMake vehicleMake) started");

            await _vehicleMakeService.Create(vehicleMakeViewModel);

            return Redirect("/");
        }

        public async Task<IActionResult> DeleteVehicleMake(int id)
        {
            _logger.LogInformation("DeleteVehicleMake(int id) started");

            await _vehicleMakeService.Delete(id);

            return Redirect("/");
        }

        public async Task<IActionResult> UpdateVehicleMake(VehicleMakeViewModel vehicleMakeViewModel, int id)
        {
            _logger.LogInformation("UpdateVehicleMake(VehicleMake vehicleMake, int id) started");

            await _vehicleMakeService.Update(vehicleMakeViewModel, id);

            return Redirect("/");
        }

        public async Task<IActionResult> DetailsVehicleMake(int id)
        {
            _logger.LogInformation("DetailsVehicleMake(int id) started");

            VehicleMakeViewModel model = await _vehicleMakeService.GetById(id);

            return View(model);
        }

        public async Task<IActionResult> PagingVehicleMake(Paging paging)
        {
            _logger.LogInformation("PagingVehicleMake(Paging paging) started");

            List<VehicleMakeViewModel> model = await _vehicleMakeService.Paging(paging);

            return View(model);
        }
    }
}
