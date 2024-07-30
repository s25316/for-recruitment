using System.Text.Json.Serialization;

namespace Radon.Models.Courses.ApiResponse.Level3
{
    public class PhilologicalLanguage
    {
        [JsonPropertyName("languageCode")]
        public string? LanguageCode { get; set; } = null;

        [JsonPropertyName("languageName")]
        public string? LanguageName { get; set; } = null!;
    }
}
