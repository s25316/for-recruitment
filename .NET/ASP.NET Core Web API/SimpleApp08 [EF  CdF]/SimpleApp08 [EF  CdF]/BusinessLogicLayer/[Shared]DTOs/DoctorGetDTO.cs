using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs
{
    public class DoctorGetDTO
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
