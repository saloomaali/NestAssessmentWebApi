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
            await policyDbContext.SVehicletype.AddAsync(vehicleType);
            await policyDbContext.SaveChangesAsync();
            return Ok(vehicleType);
        }


        //Get All Vehicle Type
        [HttpGet]
        public async Task<IActionResult> GetAllVehicleType()
        {
            try
            {
                var vehicleTypes = await policyDbContext.SVehicletype.ToListAsync();
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
                var existingVehicleType = await policyDbContext.SVehicletype.FirstOrDefaultAsync(x => x.VehicleTypeId == id);
                if (existingVehicleType == null)
                {
                    return NotFound("No VehicleType found with given id");
                }

                existingVehicleType.VehicleType = vehicleTypes.VehicleType;
                existingVehicleType.Description = vehicleTypes.Description;
                existingVehicleType.IsActive = vehicleTypes.IsActive;
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
