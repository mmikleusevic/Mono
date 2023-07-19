using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mono.Service.Services.Interfaces;
using Mono.SharedLibrary;
using System.Net.Mime;

namespace Mono.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly ILogger<VehicleMakeController> _logger;

        /// <summary>
        /// VehicleMakeController constructor,
        /// takes interface of VehicleMakeService
        /// and generic interface of Logger
        /// </summary>
        /// <param name="vehicleMakeService"></param>
        /// <param name="logger"></param>
        public VehicleMakeController(
            IVehicleMakeService vehicleMakeService,
            ILogger<VehicleMakeController> logger)
        {
            _vehicleMakeService = vehicleMakeService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a vehicle make
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateVehicleMake(VehicleMake vehicleMake)
        {
            try
            {
                if (vehicleMake != null)
                {
                    await _vehicleMakeService.CreateVehicleMake(vehicleMake);
                    return CreatedAtAction(nameof(CreateVehicleMake), new { id = vehicleMake.Id }, vehicleMake);
                }
                else
                {
                    return BadRequest("Couldn't create vehicle make");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating vehicle make");
            }
        }

        /// <summary>
        /// Deletes a vehicle make
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteVehicleMake(int id)
        {
            try
            {
                if (id > 0)
                {
                    await _vehicleMakeService.DeleteVehicleMake(id);

                    return NoContent();
                }
                return BadRequest($"Vehicle make Id mismatch");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting vehicle make");
            }
        }

        /// <summary>
        /// Returns all vehicle makes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllVehicleMakes()
        {
            try
            {
                var result = await _vehicleMakeService.GetAllVehicleMakes();
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"No vehicle makes found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting all vehicle makes");
            }
        }

        /// <summary>
        /// Return a vehicle make
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetVehicleMake(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _vehicleMakeService.GetVehicleMake(id);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                return NotFound($"Vehicle make with id = {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting vehicle make");
            }
        }

        /// <summary>
        /// Returns paged vehicle makes
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        [HttpPost("paged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PagingVehicleMakes(Paging paging)
        {
            try
            {
                var result = await _vehicleMakeService.PagingVehicleMakes(paging);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound($"No vehicle makes found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting paged vehicle makes");
            }
        }

        /// <summary>
        /// Updates a vehicle make
        /// </summary>
        /// <param name="vehicleMake"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateVehicleMake(VehicleMake vehicleMake, int id)
        {
            try
            {
                if (vehicleMake == null)
                {
                    return NotFound($"Vehicle make with id = {id} not found");
                }
                else
                {
                    if (id == vehicleMake.Id)
                    {
                        await _vehicleMakeService.UpdateVehicleMake(vehicleMake);
                        return Ok("Vehicle make successfully updated");
                    }
                    return BadRequest("Vehicle make Id mismatch");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating vehicle make");
            }
        }
    }
}
