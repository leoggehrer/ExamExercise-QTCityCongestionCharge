using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.AspMvc.Models
{
    public class Owner : VersionModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        // Advanced properties
        public string Fullname => $"{LastName} {FirstName}";
    }
}
