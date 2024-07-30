using System.ComponentModel.DataAnnotations;

namespace SimpleApp08__EF__CdF_.BusinessLogicLayer.Doctor.DTOs
{
    public class DoctorPostDTO
    {

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
    }
}
