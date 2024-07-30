namespace SimpleApp07__EF__CdF_.DatabaseLayer
{
    public class Movie
    {
        public int IdMovie { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly RelizeDate { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();

    }
}
