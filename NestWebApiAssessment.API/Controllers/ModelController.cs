using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestWebApiAssessment.API.Data;
using NestWebApiAssessment.API.Model.Domain;

namespace NestWebApiAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public readonly PolicyDbContext policyDbContext;
        public ModelController(PolicyDbContext policyDbContext) {
            this.policyDbContext = policyDbContext;
        }

        //Add Model for the existing brand 
        [HttpPost]
        public async Task<IActionResult> AddModel([FromBody] Models model)
        {
            try
            {
                var existingBrand = await policyDbContext.Brand.AnyAsync(x => x.BrandId == model.BrandId);
                if (existingBrand)
                {
                    await policyDbContext.Model.AddAsync(model);
                    await policyDbContext.SaveChangesAsync();
                    return Ok(model);
                }
                return NotFound("No such brand exists");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            

        }

        //GetAllModelByBrand.Display Brand Name along with Model details.
        [HttpGet]
        
        public async Task<IActionResult> GetAllModelByBrand()
        {
            try
            {
               // var model = policyDbContext.Model.Where(x => x.Brands.Brand == brand);

                
                    var result = await policyDbContext.Model.Include(x => x.brand)
                        .GroupBy(x => x.brand.Brand)
                        .Select(group => new
                        {
                            Brandname = group.Key,
                            models = group.ToList()
                        }).ToListAsync();
                    if (result != null)
                    {
                        return Ok(result);

                    }

                    return NotFound("No Models");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }



    }
}
