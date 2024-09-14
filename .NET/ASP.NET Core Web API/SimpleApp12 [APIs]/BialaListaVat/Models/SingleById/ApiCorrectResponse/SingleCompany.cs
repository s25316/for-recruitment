using BialaListaVat.CustomJsonConverters;
using BialaListaVat.CustomJsonConverters.ConverterStatusVat;
using BialaListaVat.CustomJsonConverters.StatusVatConverter;
using System.Text.Json.Serialization;

namespace BialaListaVat.Models.SingleById.CorrectResponse
{
    public class SingleCompany
    {
        [JsonPropertyName("authorizedClerks")]
        public List<object> AuthorizedClerks { get; set; } = new();

        [JsonPropertyName("regon")]
        public string? Regon { get; set; } = null;

        [JsonPropertyName("restorationDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? RestorationDate { get; set; } = null;

        [JsonPropertyName("workingAddress")]
        public string? WorkingAddress { get; set; } = null;

        [JsonPropertyName("hasVirtualAccounts")]
        public bool HasVirtualAccounts { get; set; }

        [JsonPropertyName("statusVat")]
        [JsonConverter(typeof(StatusVatJsonConverter))]
        public StatusVat? StatusVat { get; set; } = null!;

        [JsonPropertyName("krs")]
        public string? Krs { get; set; } = null;

        [JsonPropertyName("restorationBasis")]
        public string? RestorationBasis { get; set; } = null;

        [JsonPropertyName("accountNumbers")]
        public List<string> AccountNumbers { get; set; } = new List<string>();

        [JsonPropertyName("registrationDenialBasis")]
        public string? RegistrationDenialBasis { get; set; } = null;

        [JsonPropertyName("nip")]
        public string? Nip { get; set; } = null;

        [JsonPropertyName("removalDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? RemovalDate { get; set; } = null;

        [JsonPropertyName("partners")]
        public List<object> Partners { get; set; } = new();

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null;

        [JsonPropertyName("registrationLegalDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? RegistrationLegalDate { get; set; } = null;

        [JsonPropertyName("removalBasis")]
        public string? RemovalBasis { get; set; } = null;

        [JsonPropertyName("pesel")]
        public string? Pesel { get; set; } = null;
        [JsonPropertyName("representatives")]
        public List<object> Representatives { get; set; } = new();

        [JsonPropertyName("residenceAddress")]
        public string? ResidenceAddress { get; set; } = null;

        [JsonPropertyName("registrationDenialDate")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? RegistrationDenialDate { get; set; } = null;
    }
}
