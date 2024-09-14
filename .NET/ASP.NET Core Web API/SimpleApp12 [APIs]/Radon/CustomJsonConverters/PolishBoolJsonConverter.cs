using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.CustomJsonConverters
{
    public class PolishBoolJsonConverter : JsonConverter<bool?>
    {
        public override bool? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var text = reader.GetString();

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            return text.ToLower() switch
            {
                "tak" => true,
                "nie" => false,
                _ => throw new JsonException($"New format: {text}")
            };
        }

        public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
