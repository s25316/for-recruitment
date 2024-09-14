using System.Text.Json.Serialization;

namespace BialaListaVat.Models.SingleById.CorrectResponse
{
    public class Result
    {
        [JsonPropertyName("subject")]
        public SingleCompany Subject { get; set; } = null!;

        [JsonPropertyName("requestDateTime")]
        public string? RequestDateTime { get; set; } = null;

        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; } = null;
    }
}
