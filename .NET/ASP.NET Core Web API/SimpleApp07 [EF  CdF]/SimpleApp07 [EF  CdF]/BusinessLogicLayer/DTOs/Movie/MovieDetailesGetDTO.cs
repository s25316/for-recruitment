namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie
{
    public class MovieDetailesGetDTO
    {
        public int IdActor { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;
        public string CharacterName { get; set; } = null!;

    }
}
