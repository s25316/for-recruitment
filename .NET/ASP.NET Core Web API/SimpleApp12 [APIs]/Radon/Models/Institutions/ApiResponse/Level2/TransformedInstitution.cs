using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class TransformedInstitution
    {
        [JsonPropertyName("transformedInstitutionUuid")]
        public Guid? TransformedInstitutionUuid { get; set; } = null;

        [JsonPropertyName("transformedInstitutionName")]
        public string? TransformedInstitutionName { get; set; } = null;

        [JsonPropertyName("regon")]
        public string? Regon { get; set; } = null;

        [JsonPropertyName("nip")]
        public string? Nip { get; set; } = null;

        [JsonPropertyName("krs")]
        public string? Krs { get; set; } = null;

        [JsonPropertyName("eunNumber")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? EunNumber { get; set; } = null;

        [JsonPropertyName("panNumber")]
        public string? PanNumber { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionID")]
        public Guid? SupervisingInstitutionID { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionName")]
        public string? SupervisingInstitutionName { get; set; } = null;

        [JsonPropertyName("transformationKind")]
        public string? TransformationKind { get; set; } = null;

        [JsonPropertyName("transformationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? TransformationDate { get; set; } = null;
    }
}
