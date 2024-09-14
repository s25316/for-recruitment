namespace Application.Repositories.DTOs.EmploeePart.MethodGetForList
{
    public class EmploeeSimpleDataDtoResponse
    {
        public Guid Id { get; set; }
        public string Position { get; set; } = null!;
        public List<string> Competences { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? HandName { get; set; } = null;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
