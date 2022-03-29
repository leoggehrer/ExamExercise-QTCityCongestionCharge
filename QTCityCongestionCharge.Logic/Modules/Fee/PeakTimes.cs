namespace QTCityCongestionCharge.Logic.Modules.Fee
{
    public static class PeakTimes
    {
        private static List<PeakTime> peakTimes = new();
        static PeakTimes()
        {
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Monday,
                From = 0730,
                To = 1000,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Monday,
                From = 1530,
                To = 1800,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Tuesday,
                From = 0730,
                To = 1000,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Tuesday,
                From = 1530,
                To = 1800,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Wednesday,
                From = 0730,
                To = 1000,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Wednesday,
                From = 1530,
                To = 1800,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Thursday,
                From = 0730,
                To = 1000,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Thursday,
                From = 1530,
                To = 1800,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Friday,
                From = 0730,
                To = 1000,
            });
            peakTimes.Add(new PeakTime
            {
                DayOfWeek = DayOfWeek.Friday,
                From = 1530,
                To = 1800,
            });
        }

        public static bool IsPickTimer(DateTime dateTime)
        {
            var time = dateTime.Hour * 100 + dateTime.Minute;
            var peakTime = peakTimes.FirstOrDefault(pt => pt.DayOfWeek == dateTime.DayOfWeek && pt.From <= time && pt.To >= time);

            return peakTime != null;
        }

    }
}
