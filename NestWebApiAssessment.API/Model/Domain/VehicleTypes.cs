using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestWebApiAssessment.API.Model.Domain
{
    [Table("zVehicleType")]
    public class VehicleTypes
    {
        [Key]
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        //with many brands
        [JsonIgnore]
        public ICollection<Brands>? Brands { get; set; }

    }
}
