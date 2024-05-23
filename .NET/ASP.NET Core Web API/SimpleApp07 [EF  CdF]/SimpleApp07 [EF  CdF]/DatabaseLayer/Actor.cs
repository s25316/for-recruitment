namespace SimpleApp07__EF__CdF_.DatabaseLayer
{
    public class Actor
    {
        public int IdActor { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Nickname { get; set; } = null;

        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();
    }
}
