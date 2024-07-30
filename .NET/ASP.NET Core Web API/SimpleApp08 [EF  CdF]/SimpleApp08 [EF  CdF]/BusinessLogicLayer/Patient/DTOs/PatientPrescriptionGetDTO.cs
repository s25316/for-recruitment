using SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs;
using SimpleApp08__EF__CdF_.DatabaseLayer.Models;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs
{
    public class PatientPrescriptionGetDTO
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public virtual DoctorGetDTO Doctor { get; set; } = null!;
        public virtual IEnumerable<PrescriptionMedicamentGetDTO> Medicamens { get; set; } = new List<PrescriptionMedicamentGetDTO>(); 
    }
}
