using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Branches.CoreResponse.Level1
{
    public class Pagination
    {
        [JsonPropertyName("maxCount")]
        public int MaxCount { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; } = null;
    }
}
