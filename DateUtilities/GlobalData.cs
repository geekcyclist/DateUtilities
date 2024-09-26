using DateUtilities;

public static class GlobalData
{
    public static List<Holiday> Holidays { get; private set; } = new List<Holiday>();

    public static void AddHoliday(Holiday holiday)
    {
        Holidays.Add(holiday);
    }
}
