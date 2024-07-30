using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class FederationComposition
    {
        [JsonPropertyName("institutionUuid")]
        public Guid? InstitutionUuid { get; set; } = null;

        [JsonPropertyName("institutionName")]
        public string? InstitutionName { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;

        [JsonPropertyName("dateTo")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateTo { get; set; } = null;
    }
}
