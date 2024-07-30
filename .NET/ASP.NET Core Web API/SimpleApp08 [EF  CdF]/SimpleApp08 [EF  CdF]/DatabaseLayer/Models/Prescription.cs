namespace SimpleApp08__EF__CdF_.DatabaseLayer.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public int IdDoctor { get; set; }
        public int IdPatient { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
    }
}
