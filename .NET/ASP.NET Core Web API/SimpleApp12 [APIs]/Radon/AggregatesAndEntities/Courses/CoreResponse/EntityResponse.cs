using Radon.AggregatesAndEntities.Courses.CoreResponse.Level1;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse
{
    public class EntityResponse
    {
        [JsonPropertyName("results")]
        public List<Course> Results { get; set; } = new();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;
    }
}
