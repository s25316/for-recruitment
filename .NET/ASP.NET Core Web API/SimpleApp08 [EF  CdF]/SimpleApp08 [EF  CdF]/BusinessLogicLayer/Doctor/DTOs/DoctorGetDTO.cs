namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs
{
    public class DoctorGetDTO
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public virtual IEnumerable<DoctorPrescriptionGetDTO> Prescriptions {  get; set; } = new List<DoctorPrescriptionGetDTO>(); 
    }
}
