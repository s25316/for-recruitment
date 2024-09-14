using Radon.AggregatesAndEntities.Courses.CoreResponse.Level3;
using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse.Level2
{
    public class CourseInstance
    {
        [JsonPropertyName("courseInstanceUuid")]
        public Guid? CourseInstanceUuid { get; set; } = null;

        [JsonPropertyName("courseInstanceCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CourseInstanceCode { get; set; } = null;

        [JsonPropertyName("courseInstanceOldCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CourseInstanceOldCode { get; set; } = null;

        [JsonPropertyName("courseName")]
        public string? CourseName { get; set; } = null;

        [JsonPropertyName("formCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? FormCode { get; set; } = null;

        [JsonPropertyName("formName")]
        public string? FormName { get; set; } = null;

        [JsonPropertyName("titleCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? TitleCode { get; set; } = null;

        [JsonPropertyName("titleName")]
        public string? TitleName { get; set; } = null;

        [JsonPropertyName("languageCode")]
        public string? LanguageCode { get; set; } = null;

        [JsonPropertyName("languageName")]
        public string? LanguageName { get; set; } = null;

        [JsonPropertyName("philologicalLanguages")]
        public List<PhilologicalLanguage> PhilologicalLanguages { get; set; } = new();

        [JsonPropertyName("educationStartDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? EducationStartDate { get; set; } = null;

        [JsonPropertyName("numberOfSemesters")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? NumberOfSemesters { get; set; } = null;

        [JsonPropertyName("ects")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? Ects { get; set; } = null;

        [JsonPropertyName("dual")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? Dual { get; set; } = null;

        [JsonPropertyName("bridging")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? Bridging { get; set; } = null;

        [JsonPropertyName("statusCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? StatusCode { get; set; } = null;

        [JsonPropertyName("statusName")]
        public string? StatusName { get; set; } = null;

        [JsonPropertyName("liquidationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? LiquidationDate { get; set; } = null;

        [JsonPropertyName("coopWithVocational")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? CoopWithVocational { get; set; } = null;
    }
}
