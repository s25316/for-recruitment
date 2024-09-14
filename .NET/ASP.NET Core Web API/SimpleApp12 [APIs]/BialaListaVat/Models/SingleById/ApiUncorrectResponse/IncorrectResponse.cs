using System.Text.Json.Serialization;

namespace BialaListaVat.Models.SingleById.UncorrectResponse
{
    public class IncorrectResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }
}
