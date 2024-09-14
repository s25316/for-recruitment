using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse.Level2
{
    public class CoLeadingInstitution
    {
        [JsonPropertyName("coLeadingInstitutionUuid")]
        public string? CoLeadingInstitutionUuid { get; set; } = null;

        [JsonPropertyName("coLeadingInstitutionName")]
        public string? CoLeadingInstitutionName { get; set; } = null;

        [JsonPropertyName("isForeign")]
        public string? IsForeign { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        public string? DateFrom { get; set; } = null;

        [JsonPropertyName("dateTo")]
        public string? DateTo { get; set; } = null;
    }
}
