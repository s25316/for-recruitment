using System.ComponentModel.DataAnnotations;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Patient.DTOs
{
    public class PatientPostDTO
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [Range(1900, int.MaxValue)]
        public int Year { get; set; }
        [Range(1,12)]
        public int Month { get; set; }
        [Range(1,31)]
        public int Day { get; set; }
    }
}
