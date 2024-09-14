using Radon.AggregatesAndEntities.Institutions.CoreResponse.Level2;
using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Institutions.CoreResponse.Level1
{
    public class University
    {
        [JsonPropertyName("institutionUuid")]
        public Guid? InstitutionUuid { get; set; } = null;

        [JsonPropertyName("institutionUid")]
        public string? InstitutionUid { get; set; } = null;

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("id")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? Id { get; set; } = null;

        [JsonPropertyName("iKindCd")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? IKindCd { get; set; } = null;

        [JsonPropertyName("iKindName")]
        public string? IKindName { get; set; } = null;

        [JsonPropertyName("uTypeCd")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? UTypeCd { get; set; } = null;

        [JsonPropertyName("uTypeName")]
        public string? UTypeName { get; set; } = null;

        [JsonPropertyName("siTypeCd")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? SiTypeCd { get; set; } = null;

        [JsonPropertyName("siTypeName")]
        public string? SiTypeName { get; set; } = null;

        [JsonPropertyName("status")]
        public string? Status { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionID")]
        public Guid? SupervisingInstitutionID { get; set; } = null;

        [JsonPropertyName("supervisingInstitutionName")]
        public string? SupervisingInstitutionName { get; set; } = null;

        [JsonPropertyName("countryCd")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? CountryCd { get; set; } = null;

        [JsonPropertyName("country")]
        public string? Country { get; set; } = null;

        [JsonPropertyName("voivodeship")]
        public string? Voivodeship { get; set; } = null;

        [JsonPropertyName("city")]
        public string? City { get; set; } = null;

        [JsonPropertyName("postalCd")]
        public string? PostalCd { get; set; } = null;

        [JsonPropertyName("street")]
        public string? Street { get; set; } = null;

        [JsonPropertyName("bNumber")]
        public string? BNumber { get; set; } = null;

        [JsonPropertyName("lNumber")]
        public string? LNumber { get; set; } = null;

        [JsonPropertyName("regon")]
        public string? Regon { get; set; } = null;

        [JsonPropertyName("nip")]
        public string? Nip { get; set; } = null;

        [JsonPropertyName("krs")]
        public string? Krs { get; set; } = null;

        [JsonPropertyName("iStartDT")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? IStartDT { get; set; } = null;

        [JsonPropertyName("iLiqStartDT")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? ILiqStartDT { get; set; } = null;

        [JsonPropertyName("iLiqDT")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? ILiqDT { get; set; } = null;

        [JsonPropertyName("www")]
        public string? Www { get; set; } = null;

        [JsonPropertyName("eMail")]
        public string? EMail { get; set; } = null;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; } = null;

        [JsonPropertyName("pib")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? Pib { get; set; } = null;

        [JsonPropertyName("yearPib")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? YearPib { get; set; } = null;

        [JsonPropertyName("statusCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? StatusCode { get; set; } = null;

        [JsonPropertyName("voivodeshipCode")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? VoivodeshipCode { get; set; } = null;

        [JsonPropertyName("branches")]
        public List<Branch> Branches { get; set; } = new();

        [JsonPropertyName("managerName")]
        public string? ManagerName { get; set; } = null;

        [JsonPropertyName("managerSurname")]
        public string? ManagerSurname { get; set; } = null;

        [JsonPropertyName("managerOtherNames")]
        public string? ManagerOtherNames { get; set; } = null;

        [JsonPropertyName("managerSurnamePrefix")]
        public string? ManagerSurnamePrefix { get; set; } = null;

        [JsonPropertyName("managerEmployeeInInstitutionUuid")]
        public Guid? ManagerEmployeeInInstitutionUuid { get; set; } = null;

        [JsonPropertyName("managerFunction")]
        public string? ManagerFunction { get; set; } = null;

        [JsonPropertyName("espAddress")]
        public string? EspAddress { get; set; } = null;

        [JsonPropertyName("panNumber")]
        public string? PanNumber { get; set; } = null;

        [JsonPropertyName("ministryNumber")]
        public string? MinistryNumber { get; set; } = null;

        [JsonPropertyName("eunNumber")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? EunNumber { get; set; } = null;

        [JsonPropertyName("federationNumber")]
        [JsonConverter(typeof(StringIntJsonConverter))]
        public int? FederationNumber { get; set; } = null;

        [JsonPropertyName("federationComposition")]
        public List<FederationComposition> FederationComposition { get; set; } = new();

        [JsonPropertyName("transformedInstitutions")]
        public List<TransformedInstitution> TransformedInstitutions { get; set; } = new();

        [JsonPropertyName("targetInstitutions")]
        public List<TransformedInstitution> TargetInstitutions { get; set; } = new();

        [JsonPropertyName("names")]
        public List<Name> Names { get; set; } = new();

        [JsonPropertyName("supervisingInstitutions")]
        public List<SupervisingInstitution> SupervisingInstitutions { get; set; } = new();

        [JsonPropertyName("statuses")]
        public List<Status> Statuses { get; set; } = new();

        [JsonPropertyName("types")]
        public List<ResultType> Types { get; set; } = new();

        [JsonPropertyName("addresses")]
        public List<Address> Addresses { get; set; } = new();

        [JsonPropertyName("dataSource")]
        public string? DataSource { get; set; } = null;

        [JsonPropertyName("lastRefresh")]
        public string? LastRefresh { get; set; } = null;
    }
}
