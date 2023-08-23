using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestWebApiAssessment.API.Model.Domain
{
    [Table("zModel")]
    public class Models
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }

        //Foreign key for Models
        public int BrandId { get; set; }


        //Has one Brand
        [JsonIgnore]
        public Brands? Brands { get; set; }
    }
}
