namespace DateUtilities
{
    public class HolidayCsvService
    {


        public static bool IsHoliday(DateOnly date)
        {
            List<Holiday> holidays = ParseCsv();
            return holidays.Any(h => h.Date == date);
        }
        
        private static List<Holiday> ParseCsv()
        {
            List<Holiday> holidays = new();
            string[] lines = File.ReadAllLines("HolidayList.CSV");
            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split(',');
                holidays.Add(new Holiday
                {
                    Date = DateOnly.Parse(parts[0]),
                    Name = parts[1]
                });
            }
            return holidays;
        }
    }
}
