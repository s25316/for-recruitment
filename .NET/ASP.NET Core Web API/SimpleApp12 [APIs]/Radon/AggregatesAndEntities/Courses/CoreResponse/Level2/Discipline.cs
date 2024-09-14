using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse.Level2
{
    public class Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string? DisciplineCode { get; set; } = null;

        [JsonPropertyName("disciplineName")]
        public string? DisciplineName { get; set; } = null;

        [JsonPropertyName("disciplinePercentageShare")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? DisciplinePercentageShare { get; set; } = null;

        [JsonPropertyName("disciplineLeading")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? DisciplineLeading { get; set; } = null;
    }
}
