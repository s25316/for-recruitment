namespace Application.Repositories.DTOs.EmploeePart
{
    public class EmploymentHistoryDtoRequest
    {
        public Guid EmploeeId { get; set; }
        public string Regon { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime? To { get; set; } = null;
        public string Position { get; set; } = null!;
    }
}
