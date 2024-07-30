using System.ComponentModel.DataAnnotations;

namespace SimpleApp05__EF__DbF_.BusinessLogicLayer.Clients.DTOs
{
    public class PostClientDTO
    {
        [StringLength(120)]
        public string FirstName { get; set; } = null!;
        [StringLength(120)]
        public string LastName { get; set; } = null!;
        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [StringLength(120)]
        public string Telephone { get; set; } = null!;
        [StringLength(120)]
        public string Pesel { get; set; } = null!;
    }
}
