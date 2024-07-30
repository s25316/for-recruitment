namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs
{
    public class PatientGetDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
    }
}
