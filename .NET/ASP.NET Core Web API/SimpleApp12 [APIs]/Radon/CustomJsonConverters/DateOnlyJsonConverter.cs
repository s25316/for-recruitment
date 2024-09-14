using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.CustomJsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (string.IsNullOrEmpty(dateString))
            {
                return null;
            }

            if (DateOnly.TryParseExact(
                dateString,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateOnly date))
            {
                return date;
            }

            if (DateTime.TryParse(dateString, out var daytime))
            {
                return DateOnly.FromDateTime(daytime);
            }

            throw new JsonException($"Invalid date format: {dateString}");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStringValue(value.Value.ToString(DateFormat));

            }
        }
    }
}
