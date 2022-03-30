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
                var chargeType = GetChargeType(car);
                var maxPrice = FeeTable.GetMaxPrice(chargeType);
                var detections = car.Detections.OrderBy(d => d.Taken).ToArray();
                var dayModels = CreateDayModels(chargeType, car.Detections);

                foreach (var item in dayModels)
                {
                    if (item.To.HasValue)
                    {
                        var ts = item.To.Value - item.From;
                        var hours = Math.Ceiling(ts.TotalHours);
                        var parkingPrice = FeeTable.GetParkingPrice(item.ChargeType);

                        result += Math.Min(item.StartFee + (parkingPrice * hours), item.MaxPrice);
                    }
                }
            }
            return result;
        }
        internal static List<DayModel> CreateDayModels(ChargeType chargeType, IEnumerable<Entities.Detection> detections)
        {
            var result = new List<DayModel>();
            var maxPrice = FeeTable.GetMaxPrice(chargeType);
            var orderDetections = detections.OrderBy(d => d.Taken).ToArray();

            foreach (var item in orderDetections)
            {
                bool isPeakTime = PeakTimes.IsPickTimer(item.Taken);
                var drivingPrice = FeeTable.GetDrivingPrice(chargeType, isPeakTime);

                if (item.MovementType == Entities.MovementType.Entering)
                {
                    result.Add(new DayModel
                    {
                        ChargeType = chargeType,
                        MaxPrice = FeeTable.GetMaxPrice(chargeType),
                        StartFee = drivingPrice,
                        From = new DateTime(item.Taken.Year, item.Taken.Month, item.Taken.Day, item.Taken.Hour, 0, 0),
                    });
                }
                else if (item.MovementType == Entities.MovementType.Leaving)
                {
                    var lastModel = result.LastOrDefault();

                    if (lastModel != null)
                    {
                        if (lastModel.GetFromDayStamp() == DayModel.GetDayStamp(item.Taken))
                        {
                            lastModel.StartFee += drivingPrice;
                            lastModel.To = item.Taken;
                        }
                        else if (lastModel.GetFromDayStamp() < DayModel.GetDayStamp(item.Taken))
                        {
                            var lastDate = lastModel.From;

                            while (DayModel.GetDayStamp(lastDate) < DayModel.GetDayStamp(item.Taken))
                            {
                                lastModel.To = new DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 23, 59, 59);
                                lastDate = lastDate.AddDays(1);
                                lastDate = new DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 0, 0, 0);
                                lastModel = new DayModel
                                {
                                    ChargeType = chargeType,
                                    MaxPrice = lastModel.MaxPrice,
                                    StartFee = DayModel.GetDayStamp(lastDate) == DayModel.GetDayStamp(item.Taken) ? drivingPrice : 0,
                                    From = lastDate,
                                    To = DayModel.GetDayStamp(lastDate) == DayModel.GetDayStamp(item.Taken) ? item.Taken : null,
                                };
                                result.Add(lastModel);
                            }
                        }
                    }
                }
                else if (item.MovementType == Entities.MovementType.DrivingInside)
                {
                    var lastModel = result.LastOrDefault();

                    if (lastModel != null)
                    {
                        if (lastModel.GetFromDayStamp() == DayModel.GetDayStamp(item.Taken))
                        {
                            lastModel.StartFee += drivingPrice;
                            lastModel.To = item.Taken;
                        }
                        else if (lastModel.GetFromDayStamp() < DayModel.GetDayStamp(item.Taken))
                        {
                            var lastDate = lastModel.From;

                            while (DayModel.GetDayStamp(lastDate) < DayModel.GetDayStamp(item.Taken))
                            {
                                lastModel.To = new DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 23, 59, 59);
                                lastDate = lastDate.AddDays(1);
                                lastDate = new DateTime(lastDate.Year, lastDate.Month, lastDate.Day, 0, 0, 0);
                                lastModel = new DayModel
                                {
                                    ChargeType = chargeType,
                                    MaxPrice = lastModel.MaxPrice,
                                    StartFee = DayModel.GetDayStamp(lastDate) == DayModel.GetDayStamp(item.Taken) ? drivingPrice : 0,
                                    From = lastDate,
                                    To = DayModel.GetDayStamp(lastDate) == DayModel.GetDayStamp(item.Taken) ? item.Taken : null,
                                };
                                result.Add(lastModel);
                            }
                        }
                    }
                }
            }
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
