namespace Application.Repositories.DTOs.AdressPart
{
    public class AdministrativeDivisionDto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; } = null;
        public string? SourceId { get; set; } = null;
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public long Depth { get; set; }

    }
}
