using LibraryApp.Api.Models;
using LibraryDataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Controllers
{
    [Route("/locations")]
    [ApiController]
    public class LocationController:ControllerBase
    {
        private readonly ILocationRepository locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLocations()
        {
            try
            {
                return Ok(await locationRepository.GetLocations());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var result = await locationRepository.GetLocation(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
          
            
        }

        [HttpPut]
        public async Task<ActionResult<Location>> UpdateLocation(Location updateLocation)
        {
            try
            {
                var result = await locationRepository.GetLocation(updateLocation.id);
                if (result == null)
                {
                    return NotFound($"Location with name {updateLocation.LibraryName} is not found");
                }
                return await locationRepository.EditLocation(updateLocation);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Location>> AddLocation(Location newLocation)
        {
            try
            {
                if (newLocation == null)
                {
                    return BadRequest();
                }
                var existingLoc = await locationRepository.CheckIfLocationExists(newLocation.LibraryName);
                if (existingLoc != null)
                {
                    return BadRequest("Library Already Exists");
                }

                var result = await locationRepository.AddLocation(newLocation);
                return CreatedAtAction(nameof(GetLocation), new { id = newLocation.id }, newLocation);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Location>> DeleteLocation(int id)
        {
            try
            {
                var result = await locationRepository.GetLocation(id);
                if (result == null)
                {
                    return NotFound("Location not found ");
                }
                return await locationRepository.DeleteLocation(result.id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            
        }
    }
}
