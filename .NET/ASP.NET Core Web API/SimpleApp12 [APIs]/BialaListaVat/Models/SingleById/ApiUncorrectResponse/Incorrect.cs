using System.Text.Json.Serialization;

namespace BialaListaVat.Models.SingleById.UncorrectResponse
{
    public class Incorrect
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }
}
