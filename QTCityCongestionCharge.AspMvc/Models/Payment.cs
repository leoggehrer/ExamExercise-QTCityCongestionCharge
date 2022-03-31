using System.ComponentModel.DataAnnotations;

namespace QTCityCongestionCharge.AspMvc.Models
{
    public partial class Payment : VersionModel
    {
        public int CarId { get; set; }

        public DateTime PaidForDate { get; set; }

        public decimal PaidAmount { get; set; }

        [MaxLength(100)]
        public string PayingPerson { get; set; } = string.Empty;
    }
}
