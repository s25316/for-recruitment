using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Institutions.CoreResponse.Level2
{
    public class Status
    {
        [JsonPropertyName("statusName")]
        public string? StatusName { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;
    }
}
