using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestWebApiAssessment.API.Model.Domain
{
    [Table("zBrand")]
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

        //Foriegn Key for Brands
        public int VehicleTypeId { get; set; }


        //Has one vehicleType
        [JsonIgnore]
        public VehicleTypes? VehicleTypes { get; set; }

        //With Many Models
        [JsonIgnore]
        public ICollection<Models>? Models { get; set; }
    }
}
