using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse.Level3
{
    public class PhilologicalLanguage
    {
        [JsonPropertyName("languageCode")]
        public string? LanguageCode { get; set; } = null;

        [JsonPropertyName("languageName")]
        public string? LanguageName { get; set; } = null!;
    }
}
