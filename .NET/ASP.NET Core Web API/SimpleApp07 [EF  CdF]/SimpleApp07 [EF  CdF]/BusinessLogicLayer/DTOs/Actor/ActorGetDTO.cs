namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor
{
    public class ActorGetDTO
    {
        public int IdActor { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;
        public virtual IEnumerable<ActorDetailesGetDTO> Movies { get; set; } = new List<ActorDetailesGetDTO>();
    }
}
