using System.Text.Json.Serialization;

namespace Radon.Models.Courses.ApiResponse.Level2
{
    public class OrganizationalUnit
    {
        [JsonPropertyName("organizationalUnitUuid")]
        public Guid? OrganizationalUnitUuid { get; set; } = null;

        [JsonPropertyName("organizationalUnitFullName")]
        public string? OrganizationalUnitFullName { get; set; } = null;
    }
}
