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
                var existingBrand = await policyDbContext.SBrand.AnyAsync(x => x.BrandId == model.BrandId);
                if (existingBrand)
                {
                    await policyDbContext.SModel.AddAsync(model);
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
        [Route("{brand}")]
        public async Task<IActionResult> GetAllModelByBrand([FromRoute] string brand)
        {
            try
            {
                var model = policyDbContext.SModel.Where(x => x.Brands.Brand == brand);

                if (model != null)
                {
                    var result = model.Include(x => x.Brands)
                        .GroupBy(x => x.Brands.Brand)
                        .Select(group => new
                        {
                            Brandname = group.Key,
                            models = group.ToList()
                        });

                    return Ok(result);
                }
                return NotFound("No Models for this brand");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }



    }
}
