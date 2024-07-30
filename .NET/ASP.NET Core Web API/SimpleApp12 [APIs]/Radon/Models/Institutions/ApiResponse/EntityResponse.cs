
using Radon.Models.Institutions.ApiResponse.Level1;
using System.Text.Json.Serialization;

namespace Radon.Models.Institutions.ApiResponse
{
    public class EntityResponse
    {
        [JsonPropertyName("results")]
        public List<Result> Results { get; set; } = new ();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;
    }
}
