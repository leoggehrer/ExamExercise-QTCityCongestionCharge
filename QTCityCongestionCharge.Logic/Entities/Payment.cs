using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.Logic.Entities
{
    [Table("Payments", Schema = "App")]
    public partial class Payment : VersionEntity
    {
        public int CarId { get; set; }

        public DateTime PaidForDate { get; set; }

        [Precision(8, 2)]
        public decimal PaidAmount { get; set; }

        [MaxLength(100)]
        public string PayingPerson { get; set; } = string.Empty;

        // Navigation properties
        public Car Car { get; set; }
    }
}
