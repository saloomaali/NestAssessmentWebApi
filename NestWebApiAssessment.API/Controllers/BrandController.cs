using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestWebApiAssessment.API.Data;
using NestWebApiAssessment.API.Model.Domain;

namespace NestWebApiAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public readonly PolicyDbContext policyDbContext;
        public BrandController(PolicyDbContext policyDbContext)
        {
            this.policyDbContext = policyDbContext;
        }

        //Add Brand
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] Brands brand)
        {
            try
            {
                await policyDbContext.SBrand.AddAsync(brand);
                await policyDbContext.SaveChangesAsync();
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        //GetAllBrandsOfAVehicleType. Vehicle Type needs to be a parameter
        [HttpGet]
        [Route("{vehicleType}")]
        public async Task<IActionResult> GetAllBrandsOfAVehicleType([FromRoute] string vehicleType)
        {
            try
            {
                var Brands = await policyDbContext.SBrand.Where(x => x.VehicleTypes.VehicleType == vehicleType).ToListAsync();
                if (Brands != null)
                {
                    return Ok(Brands);

                }
                return NotFound("No record found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        //DeleteBrand
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBrand([FromRoute] int id)
        {
            try
            {
                var brand = await policyDbContext.SBrand.FindAsync(id);
                if (brand != null)
                {
                    policyDbContext.SBrand.Remove(brand);
                    await policyDbContext.SaveChangesAsync();
                    return Ok("Brand Deleted");
                }
                return NotFound("No such brand found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


    }
}
