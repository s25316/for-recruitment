using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class SupervisingInstitution
    {
        [JsonPropertyName("supervisingInstitutionID")]
        public Guid? SupervisingInstitutionID { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionName")]
        public string? SupervisingInstitutionName { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;
    }
}
