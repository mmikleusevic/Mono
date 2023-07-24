using Microsoft.AspNetCore.Mvc;
using Mono.MVC.Interfaces;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}
