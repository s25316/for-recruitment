namespace Application.Repositories.DTOs.EmploeePart.MethodGet
{
    public class EducationHistoryDtoResponse
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Fild { get; set; } = null!;
        public string Degree { get; set; } = null!;
        public string Corse { get; set; } = null!;
        public UniversityDtoResponse University { get; set; } = null!;
    }
}
