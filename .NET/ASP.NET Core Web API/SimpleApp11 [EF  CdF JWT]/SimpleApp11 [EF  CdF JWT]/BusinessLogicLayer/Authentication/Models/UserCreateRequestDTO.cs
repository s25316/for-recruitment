using System.ComponentModel.DataAnnotations;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models
{
    public class UserCreateRequestDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Surname { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Passsword { get; set; } = null!;
    }
}
