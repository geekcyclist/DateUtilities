namespace DateUtilities.Tests
{
    public class HolidayWebServiceTests
    {
        [Fact]
        public void DateIsAHoliday()
        {
            Assert.True(HolidayWebService.IsHoliday(new DateOnly(2024, 01, 01)));
        }
    }
}