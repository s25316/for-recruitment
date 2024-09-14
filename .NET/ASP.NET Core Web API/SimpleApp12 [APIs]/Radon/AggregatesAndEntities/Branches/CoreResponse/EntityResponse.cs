using Radon.AggregatesAndEntities.Branches.CoreResponse.Level1;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Branches.CoreResponse
{
    public class EntityResponse
    {
        [JsonPropertyName("results")]
        public List<Branch> Branches { get; set; } = new();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;
    }
}
