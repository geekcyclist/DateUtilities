namespace DateUtilities.Tests
{
    public class DateOnlyExtensionsTests
    {
        [Theory]
        [InlineData("2024-01-06")] // Saturday
        [InlineData("2024-12-15")] // Sunday
        public void IsBusinessDay_Weekends_Return_False(string date)
        {
            DateOnly dateOnly = DateOnly.Parse(date);
            Assert.False(dateOnly.IsBusinessDay());
        }

        [Theory]
        [InlineData("2024-02-05")] // Monday
        [InlineData("2024-03-05")] // Tuesday
        [InlineData("2024-10-23")] // Wednesday    
        [InlineData("2024-11-14")] // Thursday
        [InlineData("2024-12-27")] // Friday
        public void IsBusinessDay_Weekdays_Return_True(string date)
        {
            DateOnly dateOnly = DateOnly.Parse(date);
            Assert.True(dateOnly.IsBusinessDay());
        }

        //[Theory]
        //[InlineData("2023-01-02")] // NYD
        //[InlineData("2023-01-16")] // MLK
        //[InlineData("2023-02-20")] // Presidents
        //[InlineData("2023-05-29")] // Memorial
        //[InlineData("2023-07-04")] // Independence
        //[InlineData("2023-09-04")] // Labor
        //[InlineData("2023-10-09")] // Columbus
        //[InlineData("2023-11-10")] // Veterans
        //[InlineData("2023-11-23")] // Thanksgiving
        //[InlineData("2023-12-25")] // Christmas
        //public void IsBusinessDay_Holidays_Return_False(string date)
        //{
        //    DateOnly dateOnly = DateOnly.Parse(date);
        //    Assert.False(dateOnly.IsBusinessDay());
        //}

        //[Theory]
        //[InlineData("2023-03-29", true)] // Good Friday
        //[InlineData("2021-12-31", false)] // Shifted NYD
        //public void IsBusinessDay_Handles_Special_Cases(string date, bool expected)
        //{
        //    DateOnly dateOnly = DateOnly.Parse(date);
        //    Assert.Equal(expected, dateOnly.IsBusinessDay());
        //}
    }
}
