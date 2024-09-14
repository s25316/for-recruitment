namespace Application.Repositories.DTOs.EmploeePart.MethodGet
{
    public class EmploeeDtoResponse
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public List<string> Competences { get; set; } = null!;

        public List<EmploeeClientDtoResponse> Clients { get; set; } = new List<EmploeeClientDtoResponse>();
        public List<EmploymentHistoryDtoResponse> EmploymentHistory { get; set; } = new List<EmploymentHistoryDtoResponse>();
        public List<EducationHistoryDtoResponse> EducationHistory { get; set; } = new List<EducationHistoryDtoResponse>();

        public List<DepratmentDtoResponse> AsEmploeeInDepartments { get; set; } = new List<DepratmentDtoResponse>();
        public List<DepratmentDtoResponse> AsManagerInDepartments { get; set; } = new List<DepratmentDtoResponse>();
    }
}
