using System.ComponentModel.DataAnnotations;

namespace SimpleApp11__EF__CdF_JWT_.BusinessLogicLayer.Authentication.Models
{
    public class UserRefreshRequestDTO
    {
        [Required]
        public string RefreshToken { get; set; } = null!; 
    }
}
