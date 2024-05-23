using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs
{
    public class PrescriptionGetDTO
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual DoctorGetDTO Doctor { get; set; } = null!;
        public virtual PatientGetDTO Patient { get; set; } = null!;
        public virtual IEnumerable<PrescriptionMedicamentGetDTO> Medicaments { get; set; } = new List<PrescriptionMedicamentGetDTO>();
    }
}
