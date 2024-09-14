using Radon.AggregatesAndEntities.Institutions.CoreResponse.Level1;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Institutions.CoreResponse
{
    public class EntityResponse
    {
        [JsonPropertyName("results")]
        public List<University> Results { get; set; } = new();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;
    }
}
