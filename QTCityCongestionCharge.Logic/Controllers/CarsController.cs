using QTCityCongestionCharge.Logic.Modules.Fee;

namespace QTCityCongestionCharge.Logic.Controllers
{
    public class CarsController : GenericController<Entities.Car>
    {
        public CarsController()
        {
        }

        public CarsController(ControllerObject other) : base(other)
        {
        }

        public async Task<double> CalculateFeeAsync(int id)
        {
            var result = 0.0;
            var car = await EntitySet.Where(c => c.Id == id)
                            .Include(c => c.Detections)
                            .FirstOrDefaultAsync()
                            .ConfigureAwait(false);

            if (car != null && car.Detections.Count > 0)
            {
                DateTime? startTime = null;
                DateTime? endTime = null;
                var chargeType = GetChargeType(car);
                var maxPrice = FeeTable.GetMaxPrice(chargeType);
                var detections = car.Detections.OrderBy(d => d.Taken).ToArray();

                foreach (var item in detections)
                {
                    bool isPeakTime = PeakTimes.IsPickTimer(item.Taken);
                    var drivingPrice = FeeTable.GetDrivingPrice(chargeType, isPeakTime);

                    if (item.MovementType == Entities.MovementType.Entering)
                    {
                        startTime = item.Taken;
                        startTime = startTime.Value.AddMinutes(startTime.Value.Minute * -1);
                    }
                    else if (item.MovementType == Entities.MovementType.Leaving)
                    {
                        endTime = item.Taken;
                        endTime = endTime.Value.AddMinutes(endTime.Value.Minute * -1);
                        endTime = endTime.Value.AddHours(1);
                        if (startTime.HasValue == false)
                        {
                            startTime = endTime;
                        }
                    }
                    else
                    {
                        endTime = item.Taken;
                        endTime = endTime.Value.AddMinutes(endTime.Value.Minute * -1);
                        endTime = endTime.Value.AddHours(1);
                        if (startTime.HasValue == false)
                        {
                            startTime = endTime;
                        }
                    }
                    if (startTime.HasValue && endTime.HasValue)
                    {
                        result += CalculateParkingPrice(chargeType, drivingPrice, startTime.Value, endTime.Value);
                        startTime = endTime = null;
                    }
                    else
                    {
                        result += drivingPrice;
                    }
                }
            }
            return result;
        }
        public static double CalculateParkingPrice(ChargeType chargeType, double startPrice, DateTime startTime, DateTime endTime)
        {
            var dayPrice = startPrice;
            var maxDayPrice = FeeTable.GetMaxPrice(chargeType);
            var result = 0.0;

            while (startTime < endTime)
            {
                if (startTime.Hour == 23)
                {
                    result += Math.Min(dayPrice, maxDayPrice);
                    dayPrice = 0.0;
                }
                else
                {
                    dayPrice += FeeTable.GetParkingPrice(chargeType);
                    dayPrice = Math.Min(dayPrice, maxDayPrice);
                }
                startTime = startTime.AddHours(1);
            }
            result += dayPrice;
            return result;
        }
        public static ChargeType GetChargeType(Entities.Car car)
        {
            ChargeType result = ChargeType.FossileFules;

            if (car.CarType == Entities.CarType.PassengerCar)
            {
                result = car.IsElectricOrHybrid ? ChargeType.HybridAndElectricVehicles : ChargeType.FossileFules;
            }
            else if (car.CarType == Entities.CarType.Lorry)
            {
                result = ChargeType.Lorry;
            }
            else if (car.CarType == Entities.CarType.Van)
            {
                result = ChargeType.Van;
            }
            else if (car.CarType == Entities.CarType.Motorcycle)
            {
                result = ChargeType.Motorcycle;
            }
            return result;
        }
    }
}
