using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Branches.CoreResponse.Level2
{
    public class Name
    {
        [JsonPropertyName("name")]
        public string NameField { get; set; } = null!;  // Używamy NameField aby uniknąć konfliktu z klasą Name

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; }
    }
}
