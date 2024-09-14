using Radon.AggregatesAndEntities.Courses.CoreResponse.Level2;
using Radon.AggregatesAndEntities.Courses.CoreResponse.Level3;
using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Courses.CoreResponse.Level1
{
    public class Course
    {
        [JsonPropertyName("courseUuid")]
        public Guid? CourseUuid { get; set; } = null;

        [JsonPropertyName("courseCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CourseCode { get; set; } = null;

        [JsonPropertyName("courseOldCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CourseOldCode { get; set; } = null;

        [JsonPropertyName("courseName")]
        public string? CourseName { get; set; } = null;

        [JsonPropertyName("levelCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? LevelCode { get; set; } = null;

        [JsonPropertyName("levelName")]
        public string? LevelName { get; set; } = null;

        [JsonPropertyName("profileCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? ProfileCode { get; set; } = null;

        [JsonPropertyName("profileName")]
        public string? ProfileName { get; set; } = null;

        [JsonPropertyName("iscedCode")]
        public string? IscedCode { get; set; } = null;

        [JsonPropertyName("iscedName")]
        public string? IscedName { get; set; } = null;

        [JsonPropertyName("creationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? CreationDate { get; set; } = null;

        [JsonPropertyName("teacherTraining")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? TeacherTraining { get; set; } = null;

        [JsonPropertyName("philological")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? Philological { get; set; } = null;

        [JsonPropertyName("philologicalLanguages")]
        public List<PhilologicalLanguage> PhilologicalLanguages { get; set; } = new();

        [JsonPropertyName("coLed")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? CoLed { get; set; } = null;

        [JsonPropertyName("currentStatusCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CurrentStatusCode { get; set; } = null;

        [JsonPropertyName("currentStatusName")]
        public string? CurrentStatusName { get; set; } = null;

        [JsonPropertyName("terminationInitializationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? TerminationInitializationDate { get; set; } = null;

        [JsonPropertyName("liquidationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? LiquidationDate { get; set; } = null;

        [JsonPropertyName("disciplines")]
        public List<Discipline> Disciplines { get; set; } = new();

        [JsonPropertyName("leadingInstitutionUuid")]
        public Guid? LeadingInstitutionUuid { get; set; } = null;

        [JsonPropertyName("leadingInstitutionName")]
        public string? LeadingInstitutionName { get; set; } = null;

        [JsonPropertyName("leadingInstitutionIsForeign")]
        [JsonConverter(typeof(PolishBoolJsonConverter))]
        public bool? LeadingInstitutionIsForeign { get; set; } = null;

        [JsonPropertyName("leadingInstitutionCity")]
        public string? LeadingInstitutionCity { get; set; } = null;

        [JsonPropertyName("leadingInstitutionVoivodeship")]
        public string? LeadingInstitutionVoivodeship { get; set; } = null;

        [JsonPropertyName("leadingInstitutionVoivodeshipCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? LeadingInstitutionVoivodeshipCode { get; set; } = null;

        [JsonPropertyName("mainInstitutionUuid")]
        public Guid? MainInstitutionUuid { get; set; } = null;

        [JsonPropertyName("mainInstitutionName")]
        public string? MainInstitutionName { get; set; } = null;

        [JsonPropertyName("mainInstitutionKind")]
        public string? MainInstitutionKind { get; set; } = null;

        [JsonPropertyName("mainInstitutionKindCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? MainInstitutionKindCode { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionUuid")]
        public Guid? SupervisingInstitutionUuid { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionName")]
        public string? SupervisingInstitutionName { get; set; } = null;

        [JsonPropertyName("coLeadingInstitutions")]
        public List<CoLeadingInstitution> CoLeadingInstitutions { get; set; } = new();

        [JsonPropertyName("organizationalUnits")]
        public List<OrganizationalUnit> OrganizationalUnits { get; set; } = new();

        [JsonPropertyName("legalBasisTypeCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? LegalBasisTypeCode { get; set; } = null;

        [JsonPropertyName("legalBasisTypeName")]
        public string? LegalBasisTypeName { get; set; } = null;

        [JsonPropertyName("legalBasisNumber")]
        public string? LegalBasisNumber { get; set; } = null;

        [JsonPropertyName("legalBasisDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? LegalBasisDate { get; set; } = null;

        [JsonPropertyName("courseInstances")]
        public List<CourseInstance> CourseInstances { get; set; } = new();

        [JsonPropertyName("dataSource")]
        public string? DataSource { get; set; } = null;

        [JsonPropertyName("lastRefresh")]
        public string? LastRefresh { get; set; } = null;
    }
}
