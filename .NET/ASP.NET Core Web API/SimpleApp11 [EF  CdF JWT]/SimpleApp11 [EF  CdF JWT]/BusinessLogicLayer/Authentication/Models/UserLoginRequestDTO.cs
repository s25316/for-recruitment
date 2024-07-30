using System.ComponentModel.DataAnnotations;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models
{
    public class UserLoginRequestDTO
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
