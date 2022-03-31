using QTCityCongestionCharge.Logic.Entities;
using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.AspMvc.Models
{
    public partial class Car : VersionModel
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

        // Advanced properties
        public List<Owner> Owners { get; set; } = new();
    }
}
