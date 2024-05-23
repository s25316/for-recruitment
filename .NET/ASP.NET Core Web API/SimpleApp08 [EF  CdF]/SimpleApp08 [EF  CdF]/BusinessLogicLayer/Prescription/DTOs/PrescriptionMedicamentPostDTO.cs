using System.ComponentModel.DataAnnotations;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs
{
    public class PrescriptionMedicamentPostDTO
    {
        [Required]
        public int IdMedicament { get; set; }
        [Range(1, int.MaxValue)]
        public int? Dose { get; set; } = null;
        [Required]
        [StringLength(100)]
        public string Details { get; set; } = null!;
    }
}
