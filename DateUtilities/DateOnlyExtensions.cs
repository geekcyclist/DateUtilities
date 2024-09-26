namespace DateUtilities
{
    public static class DateOnlyExtensions
    {
        public static int GetQuarterNumber(this DateOnly date, int offset = 0)
        {
            return (int)Math.Ceiling(date.AddMonths(offset * 3).Month / 3m);
        }

        public static bool IsBusinessDay(this DateOnly date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                return false;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
