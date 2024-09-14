using System.Text.Json.Serialization;

namespace Regon.AggregatesAndEntities.Responses
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; } = false;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumProblemTypes Problem { get; set; }
        public string MessageForUser { get; set; } = null!;
        public string MessageForAdmin { get; set; } = null!;
        public T? Item { get; set; } = null;
    }
}
