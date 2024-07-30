using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class ResultType
    {
        [JsonPropertyName("typeName")]
        public string? TypeName { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;
    }
}
