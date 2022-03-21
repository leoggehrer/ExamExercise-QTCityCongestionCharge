using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.Logic.Entities
{
    [Table("Cars", Schema = "App")]
    [Index(nameof(LicensePlate), IsUnique = true)]
    public partial class Car : VersionEntity
    {
        public int OwnerId { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Make { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = string.Empty;

        public CarType CarType { get; set; }

        public bool IsElectricOrHybrid { get; set; }

        // Navigation properties
        public Owner Owner { get; set; }
        public List<Payment> Payments { get; set; } = new();
        public List<Detection> Detections { get; set; } = new();
    }
}
