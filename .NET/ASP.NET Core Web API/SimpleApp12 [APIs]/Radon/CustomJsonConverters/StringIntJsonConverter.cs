using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.CustomJsonConverters
{
    public class StringIntJsonConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringNumber = reader.GetString();

            if (string.IsNullOrEmpty(stringNumber))
            {
                return null;
            }

            if (int.TryParse(stringNumber, out var number))
            {
                return number;
            }
            throw new JsonException($"Invalid Code Int: {stringNumber}");
        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
