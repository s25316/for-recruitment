using BialaListaVat.CustomJsonConverters.StatusVatConverter;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BialaListaVat.CustomJsonConverters.ConverterStatusVat
{
    public class StatusVatJsonConverter : JsonConverter<StatusVat>
    {
        public override StatusVat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var enumString = reader.GetString();

            if (string.IsNullOrEmpty(enumString)) 
            { 
                return StatusVat.Null;
            }

            return enumString.ToLower() switch
            {
                "czynny" => StatusVat.Czynny,
                "zwolniony" => StatusVat.Zwolniony,
                "niezarejestrowany" => StatusVat.Niezarejestrowany,
                _ => throw new JsonException("Invalid value for MyEnum")
            };
        }

        public override void Write(Utf8JsonWriter writer, StatusVat value, JsonSerializerOptions options)
        {
            string? enumString = value switch
            {
                StatusVat.Czynny => "Czynny",
                StatusVat.Zwolniony => "Zwolniony",
                StatusVat.Niezarejestrowany => "Niezarejestrowany",
                StatusVat.Null => null,
                _ => throw new JsonException("Invalid value for MyEnum")
            };
            writer.WriteStringValue(enumString);
        }
    }
}
