using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestWebApiAssessment.API.Data;
using NestWebApiAssessment.API.Model.Domain;

namespace NestWebApiAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        public readonly PolicyDbContext policyDbContext;
        public VehicleTypeController(PolicyDbContext policyDbContext)
        {
            this.policyDbContext = policyDbContext;
        }

        //Add Vehicle Type
        [HttpPost]
        public async Task<IActionResult> AddVehicleType([FromBody] VehicleTypes vehicleType)
        {
            try
            {
                await policyDbContext.Vehicletype.AddAsync(vehicleType);
                await policyDbContext.SaveChangesAsync();
                return Ok(vehicleType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Get All Vehicle Type
        [HttpGet]
        public async Task<IActionResult> GetAllVehicleType()
        {
            try
            {
                var vehicleTypes = await policyDbContext.Vehicletype.ToListAsync();
                return Ok(vehicleTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //Edit Vehicle Type
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditVehicleType([FromRoute] int id, [FromBody] VehicleTypes vehicleTypes)
        {
            try
            {
                var existingVehicleType = await policyDbContext.Vehicletype.FirstOrDefaultAsync(x => x.VehicleTypeId == id);
                if (existingVehicleType == null)
                {
                    return NotFound("No VehicleType found with given id");
                }
                if (vehicleTypes.VehicleType != null)
                {
                    existingVehicleType.VehicleType = vehicleTypes.VehicleType;
                }
                if (vehicleTypes.Description != null)
                {
                    existingVehicleType.Description = vehicleTypes.Description;

                }
                if (vehicleTypes.IsActive.HasValue)
                {
                    existingVehicleType.IsActive = vehicleTypes.IsActive.Value;
                }
                await policyDbContext.SaveChangesAsync();
                return Ok(existingVehicleType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
    }
}
