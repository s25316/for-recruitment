namespace Application.Repositories.DTOs.GetPersonByPesel
{
    public class PersonDtoResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? HandName { get; set; } = null;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public bool IsPep { get; set; }
        public string? LastPositionPep { get; set; } = null;

        public EmployeeDtoResponse? EmployeeProfile { get; set; } = null;
        public ClientDtoResponse? ClientProfile { get; set; } = null;
        public ICollection<DocumentDtoResponse> Documents { get; set; } = new List<DocumentDtoResponse>();
    }
}
