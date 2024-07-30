namespace SimpleApp07__EF__CdF_.DatabaseLayer
{
    public class ActorMovie
    {
        public int IdActorMovie { get; set; }
        public int IdActor { get; set; }
        public int IdMovie { get; set; }
        public string CharacterName { get; set; } = null!;

        public Actor Actor { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
