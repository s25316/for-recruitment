namespace Application.Repositories.DTOs.PersonCreateProfile
{
    public class PersonDtoRequest
    {
        public string FirstName { get; set; } = null!;
        public string? HandName { get; set; } = null;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Pesel { get; set; } = null!;
        public bool IsPep { get; set; }
        public string? LastPositionPep { get; set; } = null;
        public AdressDtoRequest Adress { get; set; } = null!;
    }
}
