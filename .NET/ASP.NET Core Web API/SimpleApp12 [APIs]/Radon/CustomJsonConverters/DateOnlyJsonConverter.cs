using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.CustomJsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (DateOnly.TryParseExact(
                dateString, 
                DateFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out DateOnly date))
            {
                return date;
            }
            throw new JsonException("Invalid date format");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            string dateString = value.ToString(DateFormat);
            writer.WriteStringValue(dateString);
        }
    }
}
