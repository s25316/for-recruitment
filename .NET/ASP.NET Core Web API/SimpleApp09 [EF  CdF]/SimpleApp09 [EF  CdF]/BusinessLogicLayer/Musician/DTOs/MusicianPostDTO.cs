using System.ComponentModel.DataAnnotations;

namespace SimpleApp09__EF__CdF_.BusinessLogicLayer.Musician.DTOs
{
    public class MusicianPostDTO
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(40)]
        public string Surname { get; set; } = null!;
        [StringLength(50)]
        public string? Nickname { get; set; } = null;
    }
}
