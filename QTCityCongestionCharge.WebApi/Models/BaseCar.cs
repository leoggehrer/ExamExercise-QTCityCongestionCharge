using QTCityCongestionCharge.Logic.Entities;

namespace QTCityCongestionCharge.WebApi.Models
{
    public class BaseCar
    {
        public int OwnerId { get; set; }

        public string LicensePlate { get; set; } = string.Empty;

        public string Make { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public CarType CarType { get; set; }

        public bool IsElectricOrHybrid { get; set; }
    }
}
