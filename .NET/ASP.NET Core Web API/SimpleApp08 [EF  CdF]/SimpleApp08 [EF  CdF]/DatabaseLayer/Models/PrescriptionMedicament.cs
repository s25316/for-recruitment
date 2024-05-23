using System.Collections.Specialized;

namespace SimpleApp08__EF__CdF_.DatabaseLayer.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; } = null;
        public string Details { get; set; } = null!;

        public virtual Medicament Medicament { get; set; } = null!;
        public virtual Prescription Prescription { get; set; } = null!;
    }
}
