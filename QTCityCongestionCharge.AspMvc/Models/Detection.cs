using QTCityCongestionCharge.Logic.Entities;
using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.AspMvc.Models
{
    public partial class Detection : VersionModel
    {
        public DateTime Taken { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string PhotoUrl { get; set; } = string.Empty;

        public MovementType MovementType { get; set; }
    }
}
