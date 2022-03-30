namespace QTCityCongestionCharge.Logic.Modules.Fee
{
    internal class DayModel
    {
        public ChargeType ChargeType { get; set; }
        public double MaxPrice { get; set; }
        public double StartFee { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }

        public bool IsWeekend => From.DayOfWeek == DayOfWeek.Saturday || From.DayOfWeek == DayOfWeek.Sunday;
        public int GetFromDayStamp()
        {
            return GetDayStamp(From);
        }
        public int GetToDayStamp()
        {
            return To.HasValue ? GetDayStamp(To.Value) : 0;
        }
        public static int GetDayStamp(DateTime dateTime)
        {
            int result = dateTime.Year;

            result *= 100 + dateTime.Month;
            result *= 100 + dateTime.Day;

            return result;
        }
    }
}
