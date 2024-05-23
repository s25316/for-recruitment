using System.ComponentModel.DataAnnotations;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Prescription.DTOs
{
    public class PrescriptionPostDTO
    {
        [Required]
        [Range(0,int.MaxValue)]
        public int ValidityTermDays { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int IdDoctor { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int IdPatient { get; set; }
    }
}
