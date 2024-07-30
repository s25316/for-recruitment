namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs
{
    public class PatientGetDTO
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
        public virtual IEnumerable<PatientPrescriptionGetDTO> Prescriptions { get; set; } = new List<PatientPrescriptionGetDTO>();
    }
}
