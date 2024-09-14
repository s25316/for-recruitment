namespace Application.Repositories.DTOs.AdressPart
{
    public class StreetDto
    {
        public long Id { get; set; }
        public string? IdSource { get; set; } = null;
        public string Name1 { get; set; } = null!;
        public string? Name2 { get; set; } = null;
        public string? Type { get; set; } = null;
    }
}
