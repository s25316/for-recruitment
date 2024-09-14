using Radon.AggregatesAndEntities.Branches.CoreResponse.Level2;
using Radon.CustomJsonConverters;
using System.Text.Json.Serialization;

namespace Radon.AggregatesAndEntities.Branches.CoreResponse.Level1
{
    public class Branch
    {
        [JsonPropertyName("branchUuid")]
        public Guid BranchUuid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("mainInstitutionUuid")]
        public Guid? MainInstitutionUuid { get; set; }

        [JsonPropertyName("mainInstitutionName")]
        public string? MainInstitutionName { get; set; } = null;

        [JsonPropertyName("creationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? CreationDate { get; set; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; } = null!;

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        [JsonPropertyName("liquidationStartDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? LiquidationStartDate { get; set; } = null;

        [JsonPropertyName("liquidationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? LiquidationDate { get; set; } = null;

        [JsonPropertyName("regon")]
        public string Regon { get; set; } = null!;

        [JsonPropertyName("nip")]
        public string Nip { get; set; } = null!;

        [JsonPropertyName("krs")]
        public string? Krs { get; set; } = null;

        [JsonPropertyName("www")]
        public string? Www { get; set; } = null;

        [JsonPropertyName("eMail")]
        public string? EMail { get; set; } = null;

        [JsonPropertyName("phone")]
        public string? Phone { get; set; } = null;

        [JsonPropertyName("countryCd")]
        public string CountryCd { get; set; } = null!;

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; set; } = null!;

        [JsonPropertyName("voivodeshipCode")]
        public string VoivodeshipCode { get; set; } = null!;

        [JsonPropertyName("city")]
        public string City { get; set; } = null!;

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; } = null!;

        [JsonPropertyName("street")]
        public string Street { get; set; } = null!;

        [JsonPropertyName("buildingNumber")]
        public string BuildingNumber { get; set; } = null!;

        [JsonPropertyName("apartmentNumber")]
        public string? ApartmentNumber { get; set; } = null;

        [JsonPropertyName("espAddress")]
        public string? EspAddress { get; set; } = null;

        [JsonPropertyName("names")]
        public List<Name> Names { get; set; } = new();

        [JsonPropertyName("statuses")]
        public List<Status> Statuses { get; set; } = new();

        [JsonPropertyName("addresses")]
        public List<Address> Addresses { get; set; } = new();

        [JsonPropertyName("dataSource")]
        public string? DataSource { get; set; } = null;

        [JsonPropertyName("lastRefresh")]
        public string? LastRefresh { get; set; } = null;
    }
}
