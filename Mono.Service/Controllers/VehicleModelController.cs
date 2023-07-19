using Microsoft.AspNetCore.Mvc;
using Mono.Service.Services;
using Mono.Service.Services.Interfaces;
using Mono.SharedLibrary;
using System.Net.Mime;

namespace Mono.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly ILogger<VehicleModelController> _logger;

        /// <summary>
        /// VehicleModelController constructor,
        /// takes interface of VehicleModelService
        /// and generic interface of Logger
        /// </summary>
        /// <param name="vehicleModelService"></param>
        /// <param name="logger"></param>
        public VehicleModelController(
            IVehicleModelService vehicleModelService,
            ILogger<VehicleModelController> logger)
        {
            _vehicleModelService = vehicleModelService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a vehicle model
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateVehicleModel(VehicleModel vehicleModel)
        {
            try
            {
                if (vehicleModel != null)
                {
                    await _vehicleModelService.CreateVehicleModel(vehicleModel);
                    return CreatedAtAction(nameof(CreateVehicleModel), new { id = vehicleModel.Id }, vehicleModel);
                }
                else
                {
                    return BadRequest("Couldn't create vehicle model");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating vehicle model");
            }
        }

        /// <summary>
        /// Deletes a vehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVehicleModel(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _vehicleModelService.DeleteVehicleModel(id);

                    return NoContent();
                }
                return BadRequest($"Vehicle model Id mismatch");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting vehicle model");
            }
        }

        /// <summary>
        /// Returns all vehicle models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllVehicleModels()
        {
            try
            {
                var result = await _vehicleModelService.GetAllVehicleModels();
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"No Vehicle models found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all vehicle models");
            }
        }

        /// <summary>
        /// Return a vehicle model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVehicleModel(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _vehicleModelService.GetVehicleModel(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                return NotFound($"Vehicle model with id = {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting vehicle model");
            }
        }

        /// <summary>
        /// Returns pages vehicle models
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        [HttpPost("paged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PagingVehicleModels(Paging paging)
        {
            try
            {
                var result = await _vehicleModelService.PagingVehicleModels(paging);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"No vehicle models found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting paged vehicle models");
            }
        }

        /// <summary>
        /// Updates a vehicle model
        /// </summary>
        /// <param name="vehicleModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateVehicleModel(VehicleModel vehicleModel, int id)
        {
            try
            {
                if (vehicleModel == null)
                {
                    return NotFound($"Vehicle model with id = {id} not found");
                }
                else
                {
                    if (id == vehicleModel.Id)
                    {
                        await _vehicleModelService.UpdateVehicleModel(vehicleModel);
                        return Ok("Vehicle make successfully updated");
                    }
                    return BadRequest("Vehicle model Id mismatch");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating vehicle model");
            }
        }
    }
}
