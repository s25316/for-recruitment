using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Shared.Responses
{
    public class ResponseTemplate
    {
        public bool IsSuccess { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumProblemTypes Problem { get; set; }
        public string MessageForUser { get; set; } = null!;
        public string MessageForAdmin { get; set; } = null!;
    }
}
