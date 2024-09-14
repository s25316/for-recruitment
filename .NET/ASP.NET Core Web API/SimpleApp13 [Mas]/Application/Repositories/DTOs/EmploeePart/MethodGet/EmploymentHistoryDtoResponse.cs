namespace Application.Repositories.DTOs.EmploeePart.MethodGet
{
    public class EmploymentHistoryDtoResponse
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Position { get; set; } = null!;
        public CompanyDtoResponse Company { get; set; } = null!;
    }
}
