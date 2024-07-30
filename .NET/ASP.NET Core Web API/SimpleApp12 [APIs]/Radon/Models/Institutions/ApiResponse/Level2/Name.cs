using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class Name
    {
        [JsonPropertyName("name")]
        public string? NameName { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;
    }
}
