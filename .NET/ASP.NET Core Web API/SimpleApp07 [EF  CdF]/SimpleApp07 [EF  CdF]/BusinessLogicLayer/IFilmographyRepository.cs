using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor;
using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie;

namespace SimpleApp07__EF__CdF_.BusinessLogicLayer
{
    public interface IFilmographyRepository
    {
        Task<IEnumerable<ActorGetDTO>> GetActorsAsync();
        Task<IEnumerable<MovieGetDTO>> GetMoviesAsync();

        Task<bool> PostActorAsync(ActorPostDTO actor);
        Task<bool> PostMovieAsync(MoviePostDTO movie);

        Task<bool> PostActorMovieAsync(int IdActor, int IdMovie, string CharacterName);
    }
}
