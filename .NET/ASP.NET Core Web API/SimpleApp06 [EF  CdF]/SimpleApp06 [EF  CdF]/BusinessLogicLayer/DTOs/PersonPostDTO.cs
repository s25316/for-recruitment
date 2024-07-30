using System.ComponentModel.DataAnnotations;

namespace SimpleApp06__EF__CdF_.BusinessLogicLayer.DTOs
{
    public class PersonPostDTO
    {
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [StringLength(40)]
        public string Surname { get; set; } = null!;
        [StringLength(5)]
        public string? DrivingLicence { get; set; } = null;
    }
}
