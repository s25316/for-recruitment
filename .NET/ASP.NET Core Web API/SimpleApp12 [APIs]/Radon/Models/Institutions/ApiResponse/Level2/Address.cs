using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse.Level2
{
    public class Address
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; } = null;

        [JsonPropertyName("voivodeship")]
        public string? Voivodeship { get; set; } = null;

        [JsonPropertyName("city")]
        public string? City { get; set; } = null;

        [JsonPropertyName("postalCd")]
        public string? PostalCd { get; set; } = null;

        [JsonPropertyName("street")]
        public string? Street { get; set; } = null;

        [JsonPropertyName("bNumber")]
        public string? BNumber { get; set; } = null;

        [JsonPropertyName("lNumber")]
        public string? LNumber { get; set; } = null;

        [JsonPropertyName("dateFrom")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? DateFrom { get; set; } = null;
    }
}
