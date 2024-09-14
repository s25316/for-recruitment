namespace Application.Repositories.DTOs.EmploeePart
{
    public class EducationHistoryDtoRequest
    {
        public Guid EmploeeId { get; set; }
        public string Regon { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Fild { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Corse { get; set; } = null!;
    }
}
