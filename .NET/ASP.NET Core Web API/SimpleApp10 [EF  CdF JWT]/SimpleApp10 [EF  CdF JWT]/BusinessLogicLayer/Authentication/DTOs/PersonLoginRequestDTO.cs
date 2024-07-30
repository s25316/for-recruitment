using System.ComponentModel.DataAnnotations;

namespace SimpleApp10__EF__CdF_JWT_.BusinessLogicLayer.Authentication.DTOs
{
    public class PersonLoginRequestDTO
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null!;
    }
}
