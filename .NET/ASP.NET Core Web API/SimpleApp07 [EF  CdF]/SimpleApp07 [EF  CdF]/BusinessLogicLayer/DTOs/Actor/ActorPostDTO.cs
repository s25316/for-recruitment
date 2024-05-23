using System.ComponentModel.DataAnnotations;

namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor
{
    public class ActorPostDTO
    {
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        [MaxLength(50)]
        public string Surname { get; set; } = null!;
        [MaxLength(50)]
        public string? Nickname { get; set; } = null;
    }
}
