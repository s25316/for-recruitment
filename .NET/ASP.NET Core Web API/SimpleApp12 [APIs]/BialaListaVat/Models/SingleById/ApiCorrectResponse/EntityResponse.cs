using System.Text.Json.Serialization;

namespace BialaListaVat.Models.SingleById.CorrectResponse
{
    public class EntityResponse
    {
        [JsonPropertyName("result")]
        public Result Result { get; set; } = null!;
    }
}
