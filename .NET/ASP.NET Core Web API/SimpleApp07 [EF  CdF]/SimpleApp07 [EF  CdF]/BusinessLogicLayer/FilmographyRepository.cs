using Microsoft.EntityFrameworkCore;
using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Actor;
using SimpleApp07__EF__CdF_.BusinessLogicLayer.DTOs.Movie;
using SimpleApp07__EF__CdF_.DatabaseLayer;

namespace SimpleApp07__EF__CdF_.BusinessLogicLayer
{
    public class FilmographyRepository : IFilmographyRepository
    {
        private readonly DatabaseContext _dbContext;
        public FilmographyRepository (DatabaseContext dbContext) { _dbContext = dbContext; }

        public async Task<IEnumerable<ActorGetDTO>> GetActorsAsync() 
        {
            var list = await _dbContext.Actors.Include(a => a.ActorMovies).ThenInclude(a => a.Actor).AsNoTracking()
                .Select(a => new ActorGetDTO 
                { 
                    IdActor = a.IdActor,
                    Name = a.Name,
                    Surname = a.Surname,
                    Nickname = a.Nickname,
                    Movies = a.ActorMovies.Select(x => new ActorDetailesGetDTO 
                    { 
                        IdMovie = x.IdMovie,
                        Name = x.Movie.Name,
                        RelizeDate = x.Movie.RelizeDate,
                        CharacterName = x.CharacterName,

                    }).ToList(),
                }).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<MovieGetDTO>> GetMoviesAsync() 
        {
            var list = await _dbContext.Movies.Include(m => m.ActorMovies).ThenInclude(m => m.Actor).AsNoTracking().AsNoTracking()
                .Select(m => new MovieGetDTO 
                { 
                    IdMovie = m.IdMovie,
                    Name = m.Name,
                    RelizeDate= m.RelizeDate,
                    Actors = m.ActorMovies.Select(x => new MovieDetailesGetDTO 
                    { 
                        IdActor = x.IdActor,
                        Name = x.Actor.Name,
                        Surname = x.Actor.Surname,
                        Nickname = x.Actor.Nickname,
                        CharacterName = x.CharacterName,
                    }).ToList(),
                }).ToListAsync();
            return list;
        }


        public async Task<bool> PostActorAsync(ActorPostDTO actor) 
        {
            await _dbContext.Actors.AddAsync(new Actor 
            { 
                Name = actor.Name,
                Surname= actor.Surname,
                Nickname= actor.Nickname,
            });
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PostMovieAsync(MoviePostDTO movie) 
        {
            await _dbContext.Movies.AddAsync(new Movie 
            { 
                Name= movie.Name,
                RelizeDate = new DateOnly(movie.Year,movie.Month,movie.Day),
            });
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PostActorMovieAsync(int IdActor, int IdMovie, string CharacterName) 
        {
            await _dbContext.ActorMovies.AddAsync( new ActorMovie 
            { 
                IdActor = IdActor,
                IdMovie = IdMovie,
                CharacterName = CharacterName
            });
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
