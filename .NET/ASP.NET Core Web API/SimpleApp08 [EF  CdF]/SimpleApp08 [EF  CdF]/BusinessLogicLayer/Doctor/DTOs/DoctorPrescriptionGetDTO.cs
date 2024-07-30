namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs
{
    public class DoctorPrescriptionGetDTO
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public PatientGetDTO Patient { get; set; } = null!;
        public IEnumerable<PrescriptionMedicamentGetDTO>  Medicaments { get; set; } = new List<PrescriptionMedicamentGetDTO>();
    }
}
