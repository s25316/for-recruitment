using Application.Repositories.DTOs.PersonCreateProfile;

namespace Domain.Entites.DepartmentPart
{
    public class DepartmentDtoRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public AdressDtoRequest Adress { get; set; } = null!;
    }
}
