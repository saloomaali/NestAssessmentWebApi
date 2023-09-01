using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NestWebApiAssessment.API.Model.Domain
{
    
    public class Models
    {
        [Key]
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string modelname { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public bool? IsActive { get; set; }

        [JsonIgnore]
        [ForeignKey("BrandId")]
        public Brands? brand { get; set; }
    }
}
