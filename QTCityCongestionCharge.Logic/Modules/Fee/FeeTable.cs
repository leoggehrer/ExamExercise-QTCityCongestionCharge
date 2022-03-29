namespace QTCityCongestionCharge.Logic.Modules.Fee
{
    public static class FeeTable
    {
        private static Dictionary<ChargeType, Charge> feeDictionary = new();
        static FeeTable()
        {
            feeDictionary.Add(ChargeType.FossileFules, new Charge
            {
                Driving = 1.0,
                Parking = 1.0,
                RushHour = 3.0,
                MaxFee = 20.0,
            });
            feeDictionary.Add(ChargeType.ElectricVehicles, new Charge
            {
                Driving = 0.0,
                Parking = 0.0,
                RushHour = 3.0,
                MaxFee = 20.0,
            });
            feeDictionary.Add(ChargeType.HybridAndElectricVehicles, new Charge
            {
                Driving = 0.0,
                Parking = 0.0,
                RushHour = 3.0,
                MaxFee = 20.0,
            });
            feeDictionary.Add(ChargeType.Lorry, new Charge
            {
                Driving = 1.5,
                Parking = 1.5,
                RushHour = 4.5,
                MaxFee = 30.0,
            });
            feeDictionary.Add(ChargeType.Van, new Charge
            {
                Driving = 1.5,
                Parking = 1.5,
                RushHour = 4.5,
                MaxFee = 30.0,
            });
            feeDictionary.Add(ChargeType.Motorcycle, new Charge
            {
                Driving = 0.5,
                Parking = 0.5,
                RushHour = 1.5,
                MaxFee = 10.0,
            });
        }
        public static double GetParkingPrice(ChargeType chargeType)
        {
            var result = 0.0;

            if (feeDictionary.ContainsKey(chargeType))
            {
                result = feeDictionary[chargeType].Parking;
            }
            return result;
        }
        public static double GetDrivingPrice(ChargeType chargeType, bool isPeakTime)
        {
            var result = 0.0;

            if (feeDictionary.ContainsKey(chargeType))
            {
                if (isPeakTime)
                    result = feeDictionary[chargeType].RushHour;
                else
                    result = feeDictionary[chargeType].Driving;
            }
            return result;
        }
        public static double GetMaxPrice(ChargeType chargeType)
        {
            var result = 0.0;

            if (feeDictionary.ContainsKey(chargeType))
            {
                result = feeDictionary[chargeType].MaxFee;
            }
            return result;
        }
    }
}
