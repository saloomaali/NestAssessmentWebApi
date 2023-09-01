using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestWebApiAssessment.API.Model.Domain
{

    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool? IsActive { get; set; }

        [JsonIgnore]
        [ForeignKey("VehicleTypeId")]
        public VehicleTypes? vehicleType { get; set; }
        [JsonIgnore]
        public ICollection<Models>? model { get; set; }
    }
}
