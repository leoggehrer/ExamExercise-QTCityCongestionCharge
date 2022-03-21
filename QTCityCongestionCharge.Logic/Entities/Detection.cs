using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.Logic.Entities
{
    [Table("Detections", Schema = "App")]
    public partial class Detection : VersionEntity
    {
        public DateTime Taken { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string PhotoUrl { get; set; } = string.Empty;

        public MovementType MovementType { get; set; }

        // Navigation properties
        public List<Car> DetectedCars { get; set; } = new();
    }
}
