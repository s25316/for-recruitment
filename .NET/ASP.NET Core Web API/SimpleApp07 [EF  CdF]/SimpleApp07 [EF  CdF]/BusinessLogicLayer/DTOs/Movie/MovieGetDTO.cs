namespace SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie
{
    public class MovieGetDTO
    {
        public int IdMovie { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly RelizeDate { get; set; }
        public virtual IEnumerable<MovieDetailesGetDTO> Actors { get; set; } = new List<MovieDetailesGetDTO>();
    }
}
