namespace DateUtilities.Tests
{
    public class HolidayCsvServiceTests
    {
        [Fact]
        public void DateIsAHoliday()
        {
            Assert.True(HolidayCsvService.IsHoliday(new DateOnly(2021, 12, 31)));
        }
    }
}
