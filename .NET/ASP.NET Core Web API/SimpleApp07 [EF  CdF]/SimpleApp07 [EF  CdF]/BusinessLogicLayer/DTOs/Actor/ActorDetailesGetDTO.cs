namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor
{
    public class ActorDetailesGetDTO
    {
        public int IdMovie { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly RelizeDate { get; set; }
        public string CharacterName { get; set; } = null!;
    }
}
