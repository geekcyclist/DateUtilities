using System.Text.Json;
using System.Text.Json.Serialization;

namespace DateUtilities
{
    public class HolidayWebService
    {

        public static bool IsHoliday(DateOnly date)
        {
            if (!GlobalData.Holidays.Any(h => h.Date.Year == date.Year))
            {
                AddPublicHolidaysAsync(date.Year.ToString()).Wait();
            }

            return GlobalData.Holidays.Any(h => h.Date == date);
        }


        private static async Task AddPublicHolidaysAsync(string year)
        {
            string url = $"https://date.nager.at/api/v3/PublicHolidays/{year}/US";
            List<Holiday> holidays = new List<Holiday>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var publicHolidays = JsonSerializer.DeserializeAsyncEnumerable<Holiday>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateOnlyConverter() }
            });

            await foreach (var holiday in publicHolidays)
            {
                GlobalData.AddHoliday(holiday);
            }
        }
    }

    internal class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string _format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string dateString = reader.GetString();
            return DateOnly.ParseExact(dateString, _format, System.Globalization.CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
